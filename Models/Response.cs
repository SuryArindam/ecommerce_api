using System.Net;

namespace ecommerce_api.Models
{
    public class ResponseBase
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Exception SystemException { get; set; }

    }
    public class ItemResponse<T> : ResponseBase
    {        
        public T Item { get; set; }
    }
    public class ListResponse<T> : ResponseBase
    {
        public List<T> Items { get; set; }
    }
}
