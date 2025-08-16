namespace ecommerce_api
{
    public class Constants
    {
        public enum ProductCategoryStatus
        {
            Active=1,
            Inactive=2,
        }
        #region Response messages
        public static string RecordSaved = "Record is inserted successfully.";
        public static string RecordNotSaved = "Unable to save the data.";
        public static string RecordNotSavedException = "Failed to save the data.";
        public static string RecordListFound = "Record(s) is(are) fetched successfully.";
        public static string NoRecordListFound = "No data is found.";
        public static string NoRecordListFoundException = "Failed to load the list from database.";
        public static string SelectedRecordFound = "Selected record is found successfully.";
        public static string SelectedRecordNotFound = "No product category is found.";
        public static string SelectedRecordNotFoundException = "Failed to select the record from database.";
        public static string RecordRemoved = "Product Category is removed successfully.";
        public static string RecordNotRemoved = "Product Category is not removed.";
        public static string RecordNotRemovedException = "Failed to remove the selected record.";
        #endregion
    }
}
