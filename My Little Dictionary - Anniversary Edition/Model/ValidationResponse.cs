namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class ValidationResponse<T>
    {
        public List<string> Notifications { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();
        public List<string> Errors { get; set; } = new List<string>();
        public T? Result { get; set; } = default;

        public ValidationResponse() { }

        public ValidationResponse(T? result)
        {
            Result = result;
        }

        public void Deconstruct(out T? result)
        {
            result = Result;
        }


        public void Deconstruct(out T? result, out List<string> errors)
        {
            result = Result;
            errors = Errors;
        }

        public ValidationResponse<T> Merge(ValidationResponse<T> source)
        {
            MergeValidation(source);
            Result = source.Result;

            return this;
        }

        public virtual ValidationResponse<T> MergeValidation<U>(ValidationResponse<U> source)
        {
            Notifications.AddRange(source.Notifications);
            Warnings.AddRange(source.Warnings);
            Errors.AddRange(source.Errors);

            return this;
        }
    }
}
