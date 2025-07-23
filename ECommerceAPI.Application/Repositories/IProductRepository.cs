using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Domain;

namespace ECommerceAPI.Application.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product, CancellationToken cancellationToken);
        Task <List<Product>> GetAllAsync(CancellationToken cancellationToken);
    }
}
