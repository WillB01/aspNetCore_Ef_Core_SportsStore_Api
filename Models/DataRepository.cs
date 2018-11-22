using SportsStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class DataRepository : IRepository
    {
        private DataContext _context;

        public DataRepository(DataContext ctx)
            => _context = ctx;


        public IEnumerable<Product> Products => _context.Products;

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
            
    }
}
