using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Hangfire
{
    public class Hangfire : IHangfire
    {
        public IResult DoSomething()
        {
            Console.WriteLine("Oldu");
            
            return new SuccessResult();

        }
    }
}
