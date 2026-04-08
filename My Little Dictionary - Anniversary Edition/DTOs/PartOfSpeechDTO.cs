using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs
{
    public class PartOfSpeechDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PartOfSpeechDescrDTO Data { get; set; }
        public Guid? Dictionary { get; set; }
        public List<FormDTO> Forms { get; set; }

        public PartOfSpeechDTO() { }
        public PartOfSpeechDTO(PartOfSpeech model)
        {
            ID = model.ID;
            Name = model.Name;
            Description = model.Description;
            Data = new PartOfSpeechDescrDTO(model.Name, model.Description);
            Dictionary = model.Dictionary?.ID;

            if(model.Forms != null)
            {
                Forms = model.Forms
                    .Select(form => new FormDTO(form))
                    .ToList();
            }
        }
    }

    public record PartOfSpeechDescrDTO(string Name, string? Description);

    public class PartOfSpeechInsertDTO
    {
        public Guid ProjectID { get; set; }
        public PartOfSpeechDescrDTO Data { get; set; }
        public List<FormInsertDTO> Forms { get; set; }
    }
}
