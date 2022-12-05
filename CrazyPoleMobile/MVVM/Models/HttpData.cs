using System.Net;

namespace CrazyPoleMobile.MVVM.Models
{
    public class HttpData<T>
    {
        public T Data { get; set; }
        public HttpStatusCode Status { get; set; }

    }
}
