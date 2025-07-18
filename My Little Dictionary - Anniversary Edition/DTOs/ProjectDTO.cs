using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs
{
    public class ProjectDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ProjectDataDTO Data { get; set; }
        public ProjectDTO() { }
        public ProjectDTO(Project model)
        {
            ID = model.ID;
            Name = model.Name;
            Code = model.Code;
            Description = model.Description;
            Data = new ProjectDataDTO(model.Name, model.Code, model.Description);
        }
    }

    public record ProjectDataDTO(string Name, string Code, string? Description);

    public class ProjectInsertDTO
    {
        public ProjectDataDTO Data { get; set; }
        public LexiconDataDTO? Lexicon { get; set; }
        public Guid BaseLanguage { get; set; }

        public void GetData(Project model)
        {
            model.Name = Data.Name;
            model.Code = Data.Code;
            model.Description = Data.Description;
        }
    }
}
