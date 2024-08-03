using Microsoft.EntityFrameworkCore;
using RedisExample.API.Models;

namespace RedisExample.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _Context;
        public ProductRepository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
               await  _Context.Products.AddAsync(product);
                await _Context.SaveChangesAsync();
                return product;
        }
                
        public async Task <List<Product>> GetAsync() //okuma
        {
       return    await _Context.Products.ToListAsync();

        }

        public async Task <Product> GetByIdAsync(int id)
        {
            return await _Context.Products.FindAsync(id);
        }
    }
}
