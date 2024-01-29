using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.UserValidator;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using Entities.Concrete.DTOs.UserDto;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Hashing;
using System.Text;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Performance;


namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

  
        [ValidationAspect(typeof(AddUserValidator))]
        public IResult Add(User user)
        {
    
            _userDal.Add(user);
            return new SuccessResult(Messages.Add);

        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(DeleteUserValidator))]
        public IResult Delete(int id)
        {
            User deletedUser = _userDal.Get(x => x.Id == id);
            if (deletedUser != null)
            {
                _userDal.Delete(deletedUser);
                return new SuccessResult(Messages.Delete);
            }
            else
            {
                return new ErrorResult(Messages.NotData);
            }
        }

        [PerformanceAspect(5)]
        [ValidationAspect(typeof(GetUserValidator))]
        public IDataResult<GetUserDto> GetById(int id)
        {
            var getUser=_mapper.Map<GetUserDto>(_userDal.Get(x => x.Id == id));
            if (getUser != null)
            {
                return new SuccessDataResult<GetUserDto>(getUser, Messages.Get);
            }
            else
            {
                return new ErrorDataResult<GetUserDto>(Messages.NotData);
            }
        }

        public IDataResult<List<GetUserDto>> GetAll()
        {
            var User = _userDal.GetAll();
            var Users = _mapper.Map<List<GetUserDto>>(User);

            return new SuccessDataResult<List<GetUserDto>>(Users, Messages.Listed);
        }


        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.Listed);
         
        }

        public IDataResult<User> GetByMail(string email)
        {
           
            var userByMail= _userDal.Get(x => x.Email == email);
            if(userByMail != null)
            {
                return new SuccessDataResult<User>(userByMail);
            }
            else
            {
                return new ErrorDataResult<User>(Messages.EmailNotFound);
            }
        }

      

        

       


    }
}
