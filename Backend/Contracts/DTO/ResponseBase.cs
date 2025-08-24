using System.Net;

namespace Contracts.Transfers
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
