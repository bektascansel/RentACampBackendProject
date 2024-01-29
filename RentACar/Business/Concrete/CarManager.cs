using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation.BrandValidation;
using Business.ValidationRules.FluentValidation.CarValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.DTOs.CarDto;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        private readonly ICarDal _carDal ;
        private readonly IMapper _mapper;


        public CarManager(ICarDal carDal,IMapper mapper)
        {
           _carDal = carDal;
           _mapper = mapper;
        }



        [ValidationAspect(typeof(AddCarValidator))]
        [SecuredOperation("admin")]
        public IResult Add(AddCarDto carDto)
        {
            Car addedCar= _mapper.Map<Car>(carDto);
            
            _carDal.Add(addedCar);
            return new SuccessResult(Messages.Add);
      
        }



        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(DeleteCarValidator))]
        public IResult Delete(int id)
        {
            Car deletedCar = _carDal.Get(x=>x.Id == id);
            if (deletedCar != null)
            {
                _carDal.Delete(deletedCar);
                return new SuccessResult(Messages.Delete);
            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }



        [CacheAspect]
        [PerformanceAspect(5)]
        [ValidationAspect(typeof(GetCarValidator))]
        public IDataResult<Car> GetById(int id)
        {
            Car getCar=_carDal.Get(x=>x.Id==id);
            if(getCar != null)
            {
                return new SuccessDataResult<Car>(getCar, Messages.Get);
            }
            else
            {
                return new ErrorDataResult<Car>(Messages.NotData);
            }
        }


        [ValidationAspect(typeof(GetCarValidator))]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = _carDal.GetAll(x => x.Brand.Id == id);
            if(result.Count!=0)
            {
                return new SuccessDataResult<List<Car>>(result, Messages.Listed);
            }
            else
            {
                return new ErrorDataResult<List<Car>>(Messages.NotData);
            }
           
        }


        [ValidationAspect(typeof(GetCarValidator))]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = _carDal.GetAll(x => x.Color.Id == id);
            if (result.Count != 0)
            {
                return new SuccessDataResult<List<Car>>(result, Messages.Listed);
            }
            else
            {
                return new ErrorDataResult<List<Car>>(Messages.NotData);
            }  
        }



        public IDataResult<List<CarDetailDto>> GetDetailCars()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDetailCars(), Messages.Listed);
        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(UpdateCarValidator))]
        public IResult Update(UpdateCarDto carDto)
        {
            Car car=_mapper.Map<Car>(carDto);
            Car existCar = _carDal.Get(x => x.Id == car.Id);
            if (existCar != null)
            {
                
                existCar.Name = (car.Name.IsNullOrEmpty()) ? existCar.Name : car.Name;
                existCar.Description = (car.Description.IsNullOrEmpty()) ? existCar.Description : car.Description;
                existCar.DailyPrice = car.DailyPrice == 0 ? existCar.DailyPrice : car.DailyPrice;
                existCar.BrandId = car.BrandId == 0 ? existCar.BrandId : car.BrandId;
                existCar.ColorId = car.ColorId == 0 ? existCar.ColorId : car.ColorId;
                existCar.ModelYear= car.ModelYear == 0 ? existCar.ModelYear : car.ModelYear;
                _carDal.Update(existCar);
                return new SuccessResult(Messages.Update);

            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }
        }




       
    }
}
