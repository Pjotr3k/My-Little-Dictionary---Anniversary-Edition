using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs
{
    public class LanguageDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<string> OtherNames { get; set; } = new List<string>();
        public string Code { get; set; }
        public string Description { get; set; }
        public LanguageDTO() { }  
        public LanguageDTO(Language model)
        {
            ID = model.ID;
            var names = model.Name
                .Split("; ")
                .Select(x => x.Trim());

            Name = names.FirstOrDefault();
            OtherNames = names.Skip(1).ToList();
            Code = model.Code;
            Description = model.Description;
        }
    }

    public class LanguageInsertDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; } = "";

        public void GetData(Language model)
        {
            model.Name = Name;
            model.Code = Code;
            model.Description = Description;
        }
    }
}
