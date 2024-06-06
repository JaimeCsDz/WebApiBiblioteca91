namespace Domain.Entities
{
    public class Response<T>
    {
        public Response() 
        {
            
        }
        public Response(T data, string message = null)
        {
            Succeded = true;
            Message = message;
            result = data;
        }
        public Response(string message)
        {
            Succeded = false;
            Message = message;
        }

        public bool Succeded { get; set; }
        public string Message { get; set; }
        public T result { get; set; }
    }
}
