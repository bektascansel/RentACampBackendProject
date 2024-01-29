
using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs.RentalDto;

using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {

        private readonly IRentalService _rentalService;
   

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
          
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_rentalService.GetAll();

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
            var result = _rentalService.GetById(id);

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
        public IActionResult Add(AddRentalDto rentalDto)
        {
           
            var result = _rentalService.Add(rentalDto);

            if (result.Success)
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
            var result = _rentalService.Delete(id);

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
        public IActionResult Update(UpdateRentalDto rentalDto)
        {
         
            var result = _rentalService.Update(rentalDto);

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
