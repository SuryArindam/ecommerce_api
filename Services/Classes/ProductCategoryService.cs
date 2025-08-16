using ecommerce_api.Models;
using ecommerce_api.Repositories.Interfaces;
using ecommerce_api.Services.Interfaces;
using System.Net;
using static ecommerce_api.Constants;

namespace ecommerce_api.Services.Classes
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryrepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryrepository = productCategoryRepository;
        }
        public async Task<ItemResponse<SavedProductCategory>> CreateProductCategoryAsync(string name)
        {
            var response = new ItemResponse<SavedProductCategory>();
            try
            {
                var affectedRows = await _productCategoryrepository.CreateProductCategoryAsync(name);
                if (affectedRows > 0)
                {
                    response.Item = new SavedProductCategory()
                    {
                        Name = name,
                        Status = ProductCategoryStatus.Active
                    };
                    response.StatusCode = HttpStatusCode.Created;
                    response.Message = RecordSaved;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.Forbidden;
                    response.Message = RecordNotSaved;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = RecordNotSavedException;
                response.SystemException = ex;
            }
            return response;
        }

        public async Task<ListResponse<ProductCategoryItem>> GetAllProductCategory()
        {
            var response = new ListResponse<ProductCategoryItem>();
            try
            {
                var productCategoryItems= await _productCategoryrepository.GetAllProductCategoryAsync();
                if (productCategoryItems.Count() > 0)
                {
                    response.Items = productCategoryItems.ToList();
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = RecordListFound;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.Message = NoRecordListFound;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.SystemException = ex;
                response.Message = NoRecordListFoundException;
            }
            return response;
        }

        public async Task<ItemResponse<ProductCategoryItem>> GetSelectedProductCategory(Guid categoryId)
        {
            var response = new ItemResponse<ProductCategoryItem>();
            try
            {
                var result= await _productCategoryrepository.GetSelectedProductCategoryAsync(categoryId);
                if (result != null)
                {
                    response.Item = result;
                    response.StatusCode = HttpStatusCode.Found;
                    response.Message = SelectedRecordFound;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Message = SelectedRecordNotFound;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.SystemException = ex;
                response.Message = SelectedRecordNotFoundException;
            }
            return response;
        }

        public Task<ItemResponse<ProductCategoryItem>> RemoveProductCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
