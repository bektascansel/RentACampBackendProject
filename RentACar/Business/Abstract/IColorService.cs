﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs.ColorDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);
        IResult Add(AddColorDto colorDto);
        IResult Delete(int id);
        IResult Update(Color color);
    }
}
