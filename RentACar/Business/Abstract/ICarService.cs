using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs.CarDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetDetailCars();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<Car> GetById(int id);
        IResult Add(AddCarDto carDto);
        IResult Delete(int id);
        IResult Update(UpdateCarDto carDto);



    }
}
