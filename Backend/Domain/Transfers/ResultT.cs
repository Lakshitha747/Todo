namespace Domain.Transfers
{
    public sealed class Result<TValue> : Result
    {
        public TValue? Value { get; }

        internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            Value = value;
        }

        internal static Result<TValue> Success(TValue value) => new(value, true, Error.None);
        internal static new Result<TValue> Failure(Error error) => new(default, false, error);
    }
}
