
using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs.ColorDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

       private readonly IColorService _colorService;



       public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
       
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result= _colorService.GetAll();
            //var data = _mapper.Map<List<GetColorDto>>(result.Data);
           
            if (result.Success)
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
            var result = _colorService.GetById(id);
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
        public IActionResult Add([FromBody]AddColorDto colorDto)
        {
           
            var result=_colorService.Add(colorDto);

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
             var result=_colorService.Delete(id);

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
        public IActionResult Update([FromBody]Color color)
        {
            var result=_colorService.Update(color);

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
