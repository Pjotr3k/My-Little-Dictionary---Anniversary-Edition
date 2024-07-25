namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class ValidationResponse<T>
    {
        public List<string> Notifications { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();
        public List<string> Errors { get; set; } = new List<string>();
        public T? Result { get; set; } = default;

        public ValidationResponse() { }

        public void MergeValidation<U>(ValidationResponse<U> source)
        {
            Notifications.AddRange(source.Notifications);
            Warnings.AddRange(source.Warnings);
            Errors.AddRange(source.Errors);
        }
    }
}
