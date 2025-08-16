using static ecommerce_api.Constants;

namespace ecommerce_api.Models
{
    public class SavedProductCategory
    {
        public string Name { get; set; }
        public ProductCategoryStatus Status { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
