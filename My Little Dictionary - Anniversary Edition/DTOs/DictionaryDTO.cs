using My_Little_Dictionary___Anniversary_Edition.Model;
using System.Diagnostics.Eventing.Reader;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs
{
    public class DictionaryDTO
    {
    }

    public class DictionaryInsertDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Validate(ValidationResponse<Dictionary> validation)
        {
            if (string.IsNullOrEmpty(Name))
                validation.Errors.Add("The name is empty");
            else if (Name.Length > 100)
                validation.Errors.Add(string.Format("Name {0} is too long", Name));
        }
    }
}
