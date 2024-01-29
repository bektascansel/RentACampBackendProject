using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;



        public CarImageManager(IFileHelper fileHelper,ICarImageDal carImageDal)
        {
           _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }


        [SecuredOperation("admin")]
        public IResult Add(IFormFile file, int CarId)
        {
            var result = BusinessRules.Run(CheckIfCountByCarId(CarId));
            if(result != null)
            {
                return result;
            }

            string guid = _fileHelper.Add(file);
            CarImage carImage=new CarImage();
            carImage.ImagePath = guid;
            carImage.Date = DateTime.Now;
            carImage.CarId= CarId;
            _carImageDal.Add(carImage);
            return new SuccessDataResult<CarImage>(carImage,Messages.Add);




        }



        [SecuredOperation("admin")]
        public IResult Delete(int id)
        {
            var deletedCarImage=_carImageDal.Get(x=>x.Id==id);
            if(deletedCarImage != null)
            {
                _carImageDal.Delete(deletedCarImage);
                _fileHelper.Delete(deletedCarImage.ImagePath!);
                return new SuccessResult(Messages.Delete);
            }
            return new ErrorResult(Messages.NotData);
        }



        public IDataResult<List<CarImage>> GetAll()
        {
            var carImageList = _carImageDal.GetAll();
            if(carImageList != null)
            {
                return new SuccessDataResult<List<CarImage>>(carImageList,Messages.Listed);
            }
            return new ErrorDataResult<List<CarImage>>(Messages.NotData);

        }

        [PerformanceAspect(5)]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var carImageListByCarId=_carImageDal.GetAll(x=>x.CarId==carId);
            if(carImageListByCarId != null)
            {
                return new SuccessDataResult<List<CarImage>>(carImageListByCarId,Messages.Listed);
            }

            return new ErrorDataResult<List<CarImage>>(Messages.NotData);
            //carImageListByCarId.Add(new CarImage() { CarId = carId, ImagePath = "default.png" });
            //return new SuccessDataResult<List<CarImage>>(carImageListByCarId);

        }

        public IDataResult<CarImage> GetById(int id)
        {
            var getCarImage=_carImageDal.Get(x=>x.Id==id);
            if(getCarImage != null)
            {
                return new SuccessDataResult<CarImage>(getCarImage,Messages.Get);
            }
            return new ErrorDataResult<CarImage>(Messages.NotData);
        }


        [SecuredOperation("admin")]
        public IResult Update(IFormFile file, int id)
        {
            var updatedCarImage=_carImageDal.Get(x=>x.Id == id);
            if(updatedCarImage != null)
            {
                _fileHelper.Update(file, updatedCarImage.ImagePath!);
                updatedCarImage.Date = DateTime.Now;
                _carImageDal.Update(updatedCarImage);
                return new SuccessDataResult<CarImage>(updatedCarImage,Messages.Update);
            }
            return new ErrorResult(Messages.NotData);
            
        }


        private IResult CheckIfCountByCarId(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarId == carId).Count >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
