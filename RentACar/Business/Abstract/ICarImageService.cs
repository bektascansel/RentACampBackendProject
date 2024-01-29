using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface  ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Add(IFormFile file, int CarId);
        IResult Update(IFormFile file, int Id);
        IResult Delete(int id);
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetByCarId(int carId);
    }
}
