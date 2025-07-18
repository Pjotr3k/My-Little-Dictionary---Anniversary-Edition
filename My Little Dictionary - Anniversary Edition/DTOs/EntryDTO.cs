using Microsoft.IdentityModel.Tokens;
using My_Little_Dictionary___Anniversary_Edition.Validation;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs
{
    public class EntryDTO
    {

    }

    public class EntryInsertDTO
    {
        /// <summary>
        /// Guid - the guid of the Form
        /// string - the Expression of the Word
        /// </summary>
        public Dictionary<Guid, string> WordForms { get; set; } = new Dictionary<Guid, string>();
        public List<EntryDefinitionInsertDTO> Definitions { get; set; } = new List<EntryDefinitionInsertDTO>();
        public Guid DictionaryId { get; set; }

        public void Validate()
        {
            ValidationHelper.ValidateSequence(
                () => DictionaryId.ValidateOnNull(),
                () =>
                {
                    foreach (var definition in Definitions)
                        definition.Validate();
                });
        }
    }

    public class EntryDefinitionInsertDTO
    {
        public Guid? ID { get; set; }
        public string? Expression { get; set; }

        public void Validate()
        {
            if (ID == null & Expression.IsNullOrEmpty())
                throw new ValidationException("Empty definition declaration - should contain ID or Expression");
        }
    }
}
