using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.DTOs
{
    public record ProductDto(Guid Id, string Name, string Description, decimal Price, int Stock);
}
