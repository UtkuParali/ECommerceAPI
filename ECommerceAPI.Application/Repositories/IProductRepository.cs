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
        Task<List<Product>> GetAllAsync(int page, int size, CancellationToken cancellationToken);
        Task<int> GetTotalProductCountAsync(CancellationToken cancellationToken);
        Task AddAsync(Product product, CancellationToken cancellationToken);
        Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken);
        Task<Product> RemoveAsync(Product product, CancellationToken cancellationToken);
    }
}
