using ecommerce_api.Models;

namespace ecommerce_api.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ItemResponse<SavedProductCategory>> CreateProductCategoryAsync(string name);
        Task<ListResponse<ProductCategoryItem>> GetAllProductCategory();
        Task<ItemResponse<ProductCategoryItem>> GetSelectedProductCategory(Guid categoryId);
        Task<ItemResponse<ProductCategoryItem>> RemoveProductCategoryAsync(Guid categoryId);
    }
}
