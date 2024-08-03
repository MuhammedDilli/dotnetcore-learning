using RedisExample.API.Models;

namespace RedisExample.API.Repositories
{
    public interface IProductRepository
    {

        //interface içerisindekiler metodlardır
        Task<List<Product>> GetAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);



    }
}
