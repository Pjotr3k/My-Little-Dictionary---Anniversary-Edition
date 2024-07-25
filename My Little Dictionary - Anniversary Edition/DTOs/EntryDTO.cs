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
    }

    public class EntryDefinitionInsertDTO
    {
        public Guid? ID { get; set; }
        public string? Expression { get; set; }
    }
}
