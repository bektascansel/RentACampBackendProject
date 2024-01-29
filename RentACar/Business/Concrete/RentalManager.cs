using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation.RentalValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;

using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.DTOs.RentalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly IMapper _mapper;


        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(AddRentalValidator))]
        public IResult Add(AddRentalDto rentalDto)
        {
            Rental addedRental = _mapper.Map<Rental>(rentalDto);
            var result = BusinessRules.Run(CheckIfCarAvailable(addedRental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(addedRental);
            return new SuccessResult(Messages.Add);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(DeleteRentalValidator))]
        public IResult Delete(int id)
        {
            Rental deletedRental = _rentalDal.Get(x => x.Id == id);
            if (deletedRental != null)
            {
                _rentalDal.Delete(deletedRental);
                return new SuccessResult(Messages.Delete);
            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }
        }



        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }


        [PerformanceAspect(5)]
        [ValidationAspect(typeof(GetRentalValidator))]
        public IDataResult<Rental> GetById(int id)
        {
            Rental getRental = _rentalDal.Get(x => x.Id == id);

            if (getRental != null)
            {
                return new SuccessDataResult<Rental>(getRental, Messages.Get);
            }
            else
            {
                return new ErrorDataResult<Rental>(Messages.NotData);
            }
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UpdateRentalValidator))]
        public IResult Update(UpdateRentalDto rentalDto)
        {
            Rental rental = _mapper.Map<Rental>(rentalDto);
            Rental updatedRental = _rentalDal.Get(x => x.Id == rental.Id);

            if (updatedRental != null)
            {
                updatedRental.RentDate = rental.RentDate == null ? updatedRental.RentDate : rental.RentDate;
                updatedRental.ReturnDate = rental.ReturnDate == null  ? updatedRental.ReturnDate : rental.ReturnDate;
                updatedRental.CustumorId = rental.CustumorId == 0 ? updatedRental.CustumorId : rental.CustumorId;
                updatedRental.CarId = rental.CarId == 0 ? updatedRental.CarId : rental.CarId;

                var result=BusinessRules.Run(CheckIfDateCorrect(updatedRental.RentDate, updatedRental.ReturnDate));

                if (result != null)
                {
                    return result;
                }

                _rentalDal.Update(updatedRental);
                return new SuccessResult(Messages.Update);
            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }

        }

        private IResult CheckIfCarAvailable(int id)
        {
            List<Rental> rentalList = _rentalDal.GetAll(x => x.CarId == id);
            foreach (var item in rentalList)
            {
                if (item.ReturnDate == null)
                {
                    return new ErrorResult("Car is not available");
                }
            }
            return new SuccessResult();
        }

        private IResult CheckIfDateCorrect(DateTime? rentDate,DateTime? returnDate) {

            if(rentDate.Value<=returnDate.Value)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Return date must be bigger than or to equal Rent date");

        }


    }
}
