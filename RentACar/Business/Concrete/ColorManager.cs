using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation.BrandValidation;
using Business.ValidationRules.FluentValidation.ColorValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;

using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.DTOs.ColorDto;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        private readonly IMapper _mapper;

        public ColorManager(IColorDal colorDal,IMapper mapper)
        {
            _colorDal = colorDal;
            _mapper = mapper;
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(AddColorValidator))]
        public IResult Add(AddColorDto colorDto)
        {
            Color addedColor=_mapper.Map<Color>(colorDto);
            
            var result=BusinessRules.Run(CheckIfColorNameExist(addedColor.Name));

            if(result != null)
            {
                return result;
            }
          
            _colorDal.Add(addedColor);
            return new SuccessResult(Messages.Add);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(DeleteColorValidator))]
        public IResult Delete(int id)
        {
            Color deletedColor=_colorDal.Get(x=> x.Id==id);
            if(deletedColor != null)
            {
                _colorDal.Delete(deletedColor);
                return new SuccessResult(Messages.Delete);
            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }
        }



        [ValidationAspect(typeof(GetColorValidator))]
        [PerformanceAspect(5)]
        public IDataResult<Color> GetById(int id)
        {
            Color getColor = _colorDal.Get(x=>x.Id==id);
            if(getColor != null)
            {
                return new SuccessDataResult<Color>(getColor, Messages.Get);
            }
            else
            {
                return new ErrorDataResult<Color>(Messages.NotData);
            }
        }

        
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.Listed);

        }



        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UpdateColorValidator))]
        public IResult Update( Color color)
        {
            Color existColor= _colorDal.Get(x=>x.Id==color.Id);

            if(existColor != null)
            {
                var result=BusinessRules.Run(CheckIfColorNameExist(color.Name));
                if(result != null)
                {
                    return result;
                }
                existColor.Name = color.Name;
                _colorDal.Update(existColor);
                return new SuccessResult(Messages.Update);

            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }

        }


        private IResult CheckIfColorNameExist(string name)
        {
            var existName = _colorDal.GetAll(x => x.Name == name).Any();
            if (existName)
            {
                return new ErrorResult("Color Name is already exist");
            }

            return new SuccessResult();
        }
    }
}
