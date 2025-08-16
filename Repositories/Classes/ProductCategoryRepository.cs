using Dapper;
using ecommerce_api.Config;
using ecommerce_api.Models;
using ecommerce_api.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using static ecommerce_api.Constants;

namespace ecommerce_api.Repositories.Classes
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly string _connectionString;

        #region SQL queries
        private const string SqlCreateProductCategory = "INSERT INTO [dbo].[ProductCategory] " +
                   "([ProductCategoryId], [Name], [Status], [CreatedOn]) " +
                    "VALUES (@ProductCategoryId, @Name, @Status, @CreatedOn)";
        private const string SqlGetAllProductCategories = "SELECT [ProductCategoryId] AS [CategoryId]," +
                    "[Name], [Status], [IsDeleted], [CreatedOn], [UpdatedOn] " +
                    "FROM [dbo].[ProductCategory]";
        private const string SqlGetSelectedProductCategry = "SELECT [ProductCategoryId] AS [CategoryId]," +
                    "[Name], [Status] " +
                    "FROM [dbo].[ProductCategory] WHERE [ProductCategoryId]=@CategoryId " +
                    "AND [IsDeleted]=0";
        private const string SqlRemoveSelectedProductCategory = "DELETE";
        #endregion
        public ProductCategoryRepository(IAppConfig appConfig)
        {
            _connectionString = appConfig.GetConnectionString();
        }

        public async Task<int> CreateProductCategoryAsync(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var categoryId = Guid.NewGuid();
                var affectedRows = await connection.ExecuteAsync(SqlCreateProductCategory,
                     new
                     {
                         ProductCategoryId = categoryId,
                         Name = name,
                         Status = ProductCategoryStatus.Active,
                         IsDeleted = false,
                         CreatedOn = DateTime.Now,
                     });
                return affectedRows;
            }
        }

        public async Task<IEnumerable<ProductCategoryItem>> GetAllProductCategoryAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var productCategoryList = await connection.QueryAsync<ProductCategoryItem>(SqlGetAllProductCategories);
                return productCategoryList;
            }
        }

        public async Task<ProductCategoryItem> GetSelectedProductCategoryAsync(Guid categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var selectedProductCategory = await connection.QuerySingleAsync<ProductCategoryItem>(SqlGetSelectedProductCategry, new { CategoryId = categoryId });
                return selectedProductCategory;
            }
        }

        public Task<ProductCategoryItem> RemoveProductCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
