using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation.BrandValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.DTOs.BrandDto;
using FluentValidation;
using System.Reflection.Metadata.Ecma335;


namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;


        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(AddBrandValidator))]
        public IResult Add(AddBrandDto brandDto)
        {
            Brand addedBrand = _mapper.Map<Brand>(brandDto);

            var result = BusinessRules.Run(CheckIfBrandNameExist(addedBrand.Name));

            if (result != null)
            {
                return result;
            }

            _brandDal.Add(addedBrand);
            return new SuccessResult(Messages.Add);
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(DeleteBrandValidator))]
        public IResult Delete(int id)
        {

            Brand deletedBrand = _brandDal.Get(x => x.Id == id);
            if (deletedBrand != null)
            {
                _brandDal.Delete(deletedBrand);
                return new SuccessResult(Messages.Delete);
            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }

        }

        [PerformanceAspect(5)]
        [ValidationAspect(typeof(GetBrandValidator))]
        public IDataResult<Brand> GetById(int id)
        {

            Brand getBrand = _brandDal.Get(x => x.Id == id);
            if (getBrand != null)
            {
                return new SuccessDataResult<Brand>(getBrand, Messages.Get);
            }
            else
            {
                return new ErrorDataResult<Brand>(Messages.NotData);
            }

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UpdateBrandValidator))]
        public IResult Update(Brand brand)
        {
       
            Brand existBrand = _brandDal.Get(x => x.Id == brand.Id);
            if (existBrand != null)
            {
                var result=BusinessRules.Run(CheckIfBrandNameExist(brand.Name));
                if(result != null)
                {
                    return result;
                }
                existBrand.Name = brand.Name;
                _brandDal.Update(existBrand);
                return new SuccessResult(Messages.Update);
            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }

        }


        private IResult CheckIfBrandNameExist(string name)
        {
            var existName=_brandDal.GetAll(x => x.Name == name).Any();
            if(existName)
            {
                return new ErrorResult("Brand Name is already exist");
            }

            return new SuccessResult();
        }

      






    }

}

