using Dapper;
using ecommerce_api.Models;
using ecommerce_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;
using static ecommerce_api.Constants;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        [HttpPost]
        public async Task<ItemResponse<SavedProductCategory>> CreateProductCategory(string name)
        {
            return await _productCategoryService.CreateProductCategoryAsync(name);
        }
        [HttpGet]
        public async Task<ListResponse<ProductCategoryItem>> GetAllProductCategory()
        {
            return await _productCategoryService.GetAllProductCategory();
        }
        [HttpGet("categoryId={categoryId:guid}")]
        public async Task<ItemResponse<ProductCategoryItem>> GetSelectedProductCategory(Guid categoryId)
        {
            return await _productCategoryService.GetSelectedProductCategory(categoryId);
        }

    }
}
