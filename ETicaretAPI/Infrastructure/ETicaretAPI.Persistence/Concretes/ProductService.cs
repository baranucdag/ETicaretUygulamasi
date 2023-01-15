using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository_)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository_;
        }

        public IQueryable<Product> GetProducts()
        {
            return _productReadRepository.GetAll();
        }

        public async Task AddRangeAsync()
        {
            List<Product> newProducts = new List<Product>()
            {
                new(){Id=Guid.NewGuid(),Name="Laptop",CreatedDate=DateTime.Now,Price=10,Stock=10, UpdatedDate = DateTime.UtcNow},
                new(){Id=Guid.NewGuid(),Name="Phone",CreatedDate=DateTime.Now,Price=10,Stock=10,UpdatedDate=DateTime.UtcNow},
                new(){Id=Guid.NewGuid(),Name="Mouse",CreatedDate=DateTime.Now,Price=10,Stock=10,UpdatedDate=DateTime.UtcNow}
            };

           await _productWriteRepository.AddRangeAsync(newProducts);
           await _productWriteRepository.SaveAsync();
        }
    }
}
