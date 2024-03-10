using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Extensions
{
    public class UnauthenticatedException : Exception
    {
        public UnauthenticatedException() { }

        public UnauthenticatedException(string message) : base(message) { }

        public UnauthenticatedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
