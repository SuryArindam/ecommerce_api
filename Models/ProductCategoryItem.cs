using static ecommerce_api.Constants;

namespace ecommerce_api.Models
{
    public class ProductCategoryItem
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ProductCategoryStatus Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
