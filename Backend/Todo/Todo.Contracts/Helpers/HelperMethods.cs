using System.Net;
using Todo.Contracts.Exceptions;

namespace Todo.Contracts.Helpers
{
    public static class HelperMethods
    {
        public static CustomException CreateException(string message, HttpStatusCode statusCode)
        {
            var code = (int)statusCode;
            return new(message, new Exception(code.ToString()));
        }
    }
}
