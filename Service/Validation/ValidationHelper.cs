using Service.Validation;

namespace Service.Validation
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
