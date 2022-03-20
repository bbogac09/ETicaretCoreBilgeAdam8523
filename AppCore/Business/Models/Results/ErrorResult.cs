namespace AppCore.Business.Models.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool isSuccessful, string message) : base(false, message)
        {

        }

        public ErrorResult() : base(false, "")
        {

        }
    }
    public class ErrorResult<TResultType> : Result<TResultType>
    {
        public ErrorResult(string message, TResultType data) : base(false, message, data)
        {

        }

        public ErrorResult(string message) : base(false, message, default)
        {

        }

        public ErrorResult(TResultType data) : base(false, "", default)
        {

        }

        public ErrorResult() : base(false, "", default)
        {

        }
    }

}
