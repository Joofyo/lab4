using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace romannumbers
{
    class RomanNumberException : Exception
    {
        public RomanNumberException()
        {
        }
        public RomanNumberException(string message) : base(message)
        {
        }
    }
}