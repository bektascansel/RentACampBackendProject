
using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs.CustomerDto;

using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;


        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_customerService.GetAll();
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
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(AddCustomerDto customerDto)
        {
            
            var result=_customerService.Add(customerDto);

            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result=_customerService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateCustomerDto customerDto)
        {
          
            var result= _customerService.Update(customerDto);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
