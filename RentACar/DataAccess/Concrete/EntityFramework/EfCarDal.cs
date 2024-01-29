using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs.CarDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DataContext>, ICarDal
    {
        public List<CarDetailDto> GetDetailCars()
        {
            using (DataContext context = new DataContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.Id
                             join x in context.Colors
                             on p.ColorId equals x.Id
                             select new CarDetailDto
                             {
                                 CarName = p.Name,
                                 BrandName = c.Name,
                                 ColorName = x.Name,
                                 DailyPrice = p.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
