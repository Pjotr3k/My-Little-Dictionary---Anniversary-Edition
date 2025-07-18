namespace My_Little_Dictionary___Anniversary_Edition.Validation
{
    public static class ValidationHelper
    {
        public static void ValidateSequence(params Action[] validations)
        {
            List<string> invalidItems = [];
            foreach (var validation in validations)
            {
                try
                {
                    validation.Invoke();
                }
                catch (ValidationException vex)
                {
                    invalidItems.AddRange(vex.Errors);
                }
                catch
                {
                    throw;
                }
            }
        }

    }
}
