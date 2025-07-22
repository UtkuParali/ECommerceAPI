using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain
{
    public class Product
    {
        public Product(string name, string description, decimal price, int stock)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Ürün adı boş olamaz.", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Ürün fiyatı sıfırdan büyük olmalıdır.", nameof(price));
            }

            if(stock < 0)
            {
                throw new ArgumentException("Ürün stoğu negatif olamaz.", nameof(stock));
            }

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CreatedDate = DateTime.UtcNow;
        }

        private Product() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }

        public void Update(string name, string description, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Ürün adı boş olamaz.", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Ürün fiyatı sıfırdan büyük olmalıdır.", nameof(price));
            }

            if (stock < 0)
            {
                throw new ArgumentException("Ürün stoğu negatif olamaz.", nameof(stock));
            }

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
