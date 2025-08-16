using ecommerce_api.Models;

namespace ecommerce_api.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<int> CreateProductCategoryAsync(string name);
        Task<IEnumerable<ProductCategoryItem>> GetAllProductCategoryAsync();
        Task<ProductCategoryItem> GetSelectedProductCategoryAsync(Guid categoryId);
        Task<ProductCategoryItem> RemoveProductCategoryAsync(Guid categoryId);
    }
}
