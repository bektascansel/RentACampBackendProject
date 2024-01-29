using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs.RentalDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IResult Add(AddRentalDto rentalDto);
        IResult Delete(int id);
        IResult Update(UpdateRentalDto rentalDto);
    }
}
