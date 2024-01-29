
using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs.CarDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
       

        public CarsController(ICarService carService)
        {
            _carService = carService;
          
        }


        [HttpGet("getall")]
        public IActionResult GetAll() {
        
            var result = _carService.GetAll();

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
        public IActionResult GetById(int id) { 
        
            var result= _carService.GetById(id);    
            if(result.Success)
            {
                return Ok(result);
            }
            else { 
                 
                return BadRequest(result);
            }
  
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddCarDto carDto)
        {

            var result = _carService.Add(carDto);

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
        public IActionResult Delete(int id) {
        
         var result= _carService.Delete(id);

            if(result.Success)
            {
                 return Ok(result);

            }
            else
            {
                return BadRequest(result) ;
            } 
        
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateCarDto carDto)
        {
            var result= _carService.Update(carDto);

            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getdetailcars")]
        public IActionResult GetDetailCars()
        {
            var result = _carService.GetDetailCars();

            if(result.Success)
            {
                return Ok(result);
            }
            else { 
            
                return BadRequest(result);
            }
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result=_carService.GetCarsByBrandId(id);

            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if(result.Success)
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
