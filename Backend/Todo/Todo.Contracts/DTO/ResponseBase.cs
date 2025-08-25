using System.Net;

namespace Todo.Contracts.DTO
{
    public record ResponseBase
    {
        public int StatusCode { get; private set; }

        public ResponseBase(HttpStatusCode status)
        {
            StatusCode = (int)status;
        }
    }
}
