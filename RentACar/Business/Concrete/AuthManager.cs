
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.AuthValidation;
using Business.ValidationRules.FluentValidation.BrandValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete.DTOs.UserDto;
using System.Security.Claims;


namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        //Kullanıcımız login veya register olduğunda biz bu kullanıcımıza token degeri veriyoruz
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims=_userService.GetClaims(user);
            var accessToken=_tokenHelper.CreateToken(user, claims.Data);

            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }


        [ValidationAspect(typeof(LoginUserValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            //veritabanındaki hash ile oluşan hash aynı mı diye test yapılır.
            if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

       
            return new SuccessDataResult<User>(userToCheck.Data,Messages.SuccessfulLogin);
            


        }


        [ValidationAspect(typeof(RegisterUserValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            User user = new User();
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Email = userForRegisterDto.Email;
            user.FirstName= userForRegisterDto.FirstName;
            user.LastName= userForRegisterDto.LastName;
            user.Status = true;

            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if(_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }

            return new SuccessResult();

        }
    }
}
