
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete.DTOs.UserDto;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
         
        }



        [HttpGet("getall")]
        public IActionResult GetAll() {
        
          var result=_userService.GetAll();

           if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        
        
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //[HttpPost("add")]
        //public IActionResult Add(AddUserDto userDto)
        //{
          
        //    var result= _userService.Add(userDto);
        //    if(result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest(result);
        //    }

        //}

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result=_userService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        //[HttpPut("update")]
        //public IActionResult Update(UpdateUserDto userDto)
        //{
        //    var result = _userService.Update(userDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest(result);
        //    }
        //}

    }
}
