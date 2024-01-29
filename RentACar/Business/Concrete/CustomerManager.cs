using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation.ColorValidation;
using Business.ValidationRules.FluentValidation.CustomerValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.DTOs.CustomerDto;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(AddCustomerValidator))]
        public IResult Add(AddCustomerDto customerDto)
        {
            Customer addedCustomer = _mapper.Map<Customer>(customerDto);

            var result = BusinessRules.Run(CheckIfCompanyNameExist(addedCustomer.CompanyName));

            if (result != null)
            {
                return result;
            }

            _customerDal.Add(addedCustomer);
            return new SuccessResult(Messages.Add);
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(DeleteCustomerValidator))]
        public IResult Delete(int id)
        {
            Customer deletedCustomer = _customerDal.Get(x => x.Id == id);
            if (deletedCustomer != null)
            {
                _customerDal.Delete(deletedCustomer);
                return new SuccessResult(Messages.Delete);
            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }
        }


        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
        }

        [PerformanceAspect(5)]
        [ValidationAspect(typeof(GetCustomerValidator))]
        public IDataResult<Customer> GetById(int id)
        {
            Customer getCustomer = _customerDal.Get(x => x.Id == id);
            if (getCustomer != null)
            {
                return new SuccessDataResult<Customer>(getCustomer, Messages.Get);
            }
            else
            {
                return new ErrorDataResult<Customer>(Messages.NotData);
            }
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UpdateCustomerValidator))]
        public IResult Update(UpdateCustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);
            Customer updatedCustomer = _customerDal.Get(x => x.Id == customer.Id);

            if (updatedCustomer != null)
            {
                var result = BusinessRules.Run(CheckIfCompanyNameExist(customer.CompanyName));

                if (result != null)
                {
                    return result;
                }

                updatedCustomer.CompanyName = (customer.CompanyName.IsNullOrEmpty()) ? updatedCustomer.CompanyName : customer.CompanyName;
                updatedCustomer.UserId = customer.UserId == 0 ? updatedCustomer.UserId : customer.UserId;
                _customerDal.Update(updatedCustomer);
                return new SuccessResult(Messages.Update);


            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }
        }

        private IResult CheckIfCompanyNameExist(string name)
        {
            var existName = _customerDal.GetAll(x => x.CompanyName == name).Any();
            if (existName)
            {
                return new ErrorResult("Company Name is already exist");
            }

            return new SuccessResult();
        }
    }
}
