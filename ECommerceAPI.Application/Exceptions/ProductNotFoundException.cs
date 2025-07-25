using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Exceptions
{
    public class ProductNotFoundException : System.Exception
    {
        public ProductNotFoundException(Guid productId) 
            : base($"Product with ID '{productId}' was not found.")
        {

        }

        public ProductNotFoundException(string message) 
            : base(message) 
        { 

        }
    }
}
