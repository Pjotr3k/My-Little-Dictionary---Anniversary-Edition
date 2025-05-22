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
        public LanguageDTO Language { get; set; }
        public ProjectDTO() { }
        public ProjectDTO(Project model)
        {
            ID = model.ID;
            Name = model.Name;
            Code = model.Code;
            Description = model.Description;
            Data = new ProjectDataDTO(model.Name, model.Code, model.Description);
            Language = new LanguageDTO(model.Language);
        }
    }

    public record ProjectDataDTO(string Name, string Code, string? Description);

    public class ProjectInsertDTO
    {

        public Guid Language { get; set; }
        public ProjectDataDTO Data { get; set; }

        public void GetData(Project model, Language language)
        {
            model.Name = Data.Name;
            model.Code = Data.Code;
            model.Description = Data.Description;
            model.Language = language;
        }
    }
}
