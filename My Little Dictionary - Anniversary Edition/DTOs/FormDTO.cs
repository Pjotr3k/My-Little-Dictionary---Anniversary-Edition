using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs
{
    public class FormDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid? PartOfSpeech { get; set; }

        public FormDTO()
        {
            
        }

        public FormDTO(Form model)
        {
            Name = model.Name;
            Description = model.Description;
            PartOfSpeech = model.PartOfSpeech?.ID;
        }

    }

    public class FormInsertDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid PartOfSpeech { get; set; }
    }

}
