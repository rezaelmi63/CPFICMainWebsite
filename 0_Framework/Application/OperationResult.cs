namespace _0_Framework.Application
{
    public class OperationResult
    {
        public OperationResult()
        {
            IsSuccessed = false;
        }

        public bool IsSuccessed { get; set; }
        public string Message { get; set; }

        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccessed = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSuccessed = false;
            Message = message;
            return this;
        }

        public OperationResult Failed(object passwordsNotMatch)
        {
            throw new NotImplementedException();
        }
    }
}
