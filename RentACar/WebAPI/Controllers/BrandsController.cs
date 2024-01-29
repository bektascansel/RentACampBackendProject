
using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs.BrandDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
            
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
           
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
            var result=_brandService.GetById(id);

            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("add")]
        public IActionResult Add([FromBody]AddBrandDto brandDto)
        {
           
            var result=_brandService.Add(brandDto);
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
            var result = _brandService.Delete(id);

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
        public IActionResult Update([FromBody] Brand brand)
        {
            var result = _brandService.Update(brand);

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
