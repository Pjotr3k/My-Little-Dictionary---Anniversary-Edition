namespace My_Little_Dictionary___Anniversary_Edition.Validation
{
    public class ValidationException : Exception
    {
        const string Message = "Validation error(s) occured";
        public List<string> Errors { get; set; }
        public ValidationException(string error) : base(Message)
        {
            Errors = [error];
        }

        public ValidationException(string error, Exception inner) : base(Message, inner)
        {
            Errors = [error];
        }

        public ValidationException(List<string> errors) : base(Message)
        {
            Errors = [.. errors];
        }

        public ValidationException(List<string> errors, Exception inner) : base(Message, inner)
        {
            Errors = [.. errors];
        }
    }
}
