namespace Unity.Living.App.Portable.Models
{
    public class ApiResult<T> where T : class
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
