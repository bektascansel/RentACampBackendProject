﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.GuideHelper
{
    public class GuidHelper
    {

        public static string Create()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
