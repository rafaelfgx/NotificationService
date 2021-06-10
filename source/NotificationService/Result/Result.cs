namespace NotificationService
{
    public sealed class Result : IResult
    {
        private Result() { }

        public string Message { get; private set; }

        public bool Succeeded { get; private set; }

        public static IResult Fail(string message)
        {
            return new Result { Succeeded = false, Message = message };
        }

        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }
    }
}
