using My_Little_Dictionary___Anniversary_Edition.Validation;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs
{
    public class LexiconDTO
    {
        public Guid ID { get; set; }
        public LexiconDataDTO Data { get; set; }
        public ProjectDTO Project { get; set; }
        public LanguageDTO Language { get; set; }
    }

    public class LexiconInsertDTO
    {
        public LexiconDataDTO Data { get; set; }
        public Guid ProjectID { get; set; }
        public Guid LanguageID { get; set; }

        public void Validate()
        {
            List<string> errors = [];

            if (string.IsNullOrEmpty(Data.Name))
                errors.Add("The name is empty");
            else if (Data.Name.Length > 100)
                errors.Add(string.Format("Name {0} is too long", Data.Name));

            if (errors.Count != 0)
            {
                throw new ValidationException(errors);
            }
        }
    }

    public record LexiconDataDTO(string Name, string Description);
}
