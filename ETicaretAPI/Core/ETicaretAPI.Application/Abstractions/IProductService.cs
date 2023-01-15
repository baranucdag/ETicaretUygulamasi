using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstractions
{
    public interface IProductService
    {
        IQueryable<Product> GetProducts();
        Task AddRangeAsync();
    }
}
