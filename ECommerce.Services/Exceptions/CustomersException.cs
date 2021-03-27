using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Services.Exceptions
{
    public class CustomersException : Exception
    {
        public CustomersException()
        {

        }
        public CustomersException(string message) : base(message)
        {

        }
    }
}
