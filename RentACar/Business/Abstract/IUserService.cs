﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService 
    {
        IDataResult<List<GetUserDto>> GetAll();
        IDataResult<GetUserDto> GetById(int id);
        IResult Add(User user);
        IResult Delete(int id);
        //IResult Update(UpdateUserDto userDto);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

    }
}
