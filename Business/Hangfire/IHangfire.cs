﻿using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Hangfire
{
    public interface IHangfire
    {
        IResult DoSomething();
    }
}
