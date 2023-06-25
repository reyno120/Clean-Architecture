using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ArgumentNulOrEmptyException : Exception
    {
        public ArgumentNulOrEmptyException()
        {
        }

        public ArgumentNulOrEmptyException(string parameterName)
            : base(parameterName + " cannot be Null or Empty.")
        {
        }
    }
}
