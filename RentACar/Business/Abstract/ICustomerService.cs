using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs.CustomerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IResult Add(AddCustomerDto customerDto);
        IResult Delete(int id);
        IResult Update(UpdateCustomerDto customerDto);

    }
}
