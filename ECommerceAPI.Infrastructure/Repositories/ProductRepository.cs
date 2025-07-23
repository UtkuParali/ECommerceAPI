using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain;
using ECommerceAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;
        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
