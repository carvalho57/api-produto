namespace Products.Models
{
    public class Response
    {
        public Response() { }
        public Response(bool status,object data)
        {
            Status = status;
            Message = string.Empty;            
            Data = data;
        }
        public Response(bool status, string message , object data = null)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }


    }
}