using System.Net;

namespace PokemonApp.Helper
{
    public class Helper
    {
        //public class ResponseBody<T>
        public class ResponseBody
        {
            public string Message { get; set; }
            public bool Status { get; set; }
            public object Data { get; set; }
            //public T Data { get; set; }
            public HttpStatusCode StatusCode { get; set; }
        }
        public class ResponseBody<T>
        {
            public string Message { get; set; }
            public bool Status { get; set; }
            public T Data { get; set; }
            public HttpStatusCode StatusCode { get; set; }
        }
    }
}
