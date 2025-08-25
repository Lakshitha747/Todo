namespace Todo.Domain.Transfers
{
    public class Result
    {
        public bool IsSuccessful { get; }
        public Error Error { get; }

        protected internal Result(bool isSuccessful, Error error)
        {
            if (isSuccessful && error != Error.None || !isSuccessful && error == Error.None)
            {
                throw new ArgumentException();
            }

            IsSuccessful = isSuccessful;
            Error = error;
        }

        internal static Result Success() => new(true, Error.None);
        internal static Result Failure(Error error) => new(false, error);
    }
}
