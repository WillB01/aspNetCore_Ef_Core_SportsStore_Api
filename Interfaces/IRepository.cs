using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        Task AddProduct(Product product);

        Task<Product> GetProduct(long key);

        Task UpdateProduct(Product product);

        Task DeleteProduct(long key);
    }
}
