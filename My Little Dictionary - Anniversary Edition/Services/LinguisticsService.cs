using Azure.Core;
using Microsoft.EntityFrameworkCore;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Helpers;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Base;
using My_Little_Dictionary___Anniversary_Edition.Services.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Services
{
    public class LinguisticsService : BaseContextService, ILinguisticsService
    {
        public LinguisticsService(ApplicationDBContext context) : base(context)
        {

        }
        //public ValidationResponse<Form> AddForm(FormInsertDTO request, PartOfSpeech pos)
        //{
        //    ValidationResponse<Form> validation = new ValidationResponse<Form>();

        //     //= _context.PartOfSpeech.FirstOrDefault(x => x.ID == request.PartOfSpeech);

        //    if (pos == null)
        //    {
        //        validation.Errors.Add(string.Format("No part of speach with id {0}", request.PartOfSpeech.ToString()));
        //        return validation;
        //    }

        //    Form form = new Form()
        //    {
        //        Name = request.Name,
        //        Description = request.Description != null ? request.Description : "",
        //        PartOfSpeech = pos
        //    };

        //    _context.Add(form);
        //    _context.SaveChanges();
        //    validation.Result = form;

        //    return validation;
        //}

        public ValidationResponse<Project> AddProject(ProjectInsertDTO request)
        {
            ValidationResponse<Project> validation = new ValidationResponse<Project>();

            var (language, _) = GetLanguageById(request.Language);

            if (language == null)
            {
                validation.Errors.Add("Language not found");
                return validation;
            }

            Project project = new Project();

            request.GetData(project, language);

            _context.Add(project);
            _context.SaveChanges();
            validation.Result = project;

            return validation;
        }

        public ValidationResponse<Language> AddLanguage(LanguageInsertDTO request)
        {
            ValidationResponse<Language> validation = new ValidationResponse<Language>();

            Language language = new Language();

            request.GetData(language);

            _context.Add(language);
            _context.SaveChanges();
            validation.Result = language;

            return validation;
        }

        public void CSVImportLangs()
        {
            string csvContent = File.ReadAllText("C:\\Users\\User\\OneDrive\\Pulpit\\lang.csv");
            var languages = new List<Language>();

            using (var reader = new StringReader(csvContent))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(',');

                    if (fields.Length >= 3)
                    {
                        var language = new Language
                        {
                            Code = fields[0].Trim('\"'),  // "alpha3-b" => Code
                            Name = fields[2].Trim('\"'),  // "English" => Name
                            Description = string.Empty    // Description left as empty string
                        };

                        languages.Add(language);
                    }
                }
            }

            foreach (var language in languages)
            {
                _context.Add(language);
            }
            _context.SaveChanges();
        }

        public ValidationResponse<PartOfSpeech> AddPartOfSpeech(PartOfSpeechInsertDTO request)
        {
            ValidationResponse<PartOfSpeech> validation = new ValidationResponse<PartOfSpeech>();

            Project language = _context.Project.FirstOrDefault(x => x.ID == request.Language);

            if (language == null)
            {
                validation.Errors.Add(string.Format("No language with id {0}", request.Language.ToString()));
                return validation;
            }

            PartOfSpeech pos = new PartOfSpeech()
            {
                Name = request.Name,
                Description = request.Description != null ? request.Description : "",
                Project = language,
            };

            _context.Add(pos);

            foreach(var item in request.Forms)
            {
                Form form = new Form()
                {
                    Description = item.Description,
                    Name = item.Name,
                    PartOfSpeech = pos,
                };

                _context.Add(form);
            }

            _context.SaveChanges();
            validation.Result = pos;

            return validation;

        }

        //public ValidationResponse<List<Form>> BulkAddForm(List<FormInsertDTO> request)
        //{
        //    ValidationResponse<List<Form>> validation = new ValidationResponse<List<Form>>();
        //    List<Form> forms = new List<Form>();

        //    foreach (var item in request)
        //    {
        //        PartOfSpeech pos = _context.PartOfSpeech.FirstOrDefault(x => x.ID == item.PartOfSpeech);

        //        if (pos == null)
        //        {
        //            validation.Errors.Add(string.Format("No part of speach with id {0}", item.PartOfSpeech.ToString()));
        //            continue;
        //        }

        //        Form form = new Form()
        //        {
        //            Name = item.Name,
        //            Description = item.Description != null ? item.Description : "",
        //            PartOfSpeech = pos
        //        };

        //        forms.Add(form);
        //    }

        //    if (validation.Errors.Any()) return validation;

        //    _context.AddRange(forms);
        //    _context.SaveChanges();
        //    validation.Result = forms;

        //    return validation;
        //}

        public ValidationResponse<List<Form>> GetAllForms()
        {
            ValidationResponse<List<Form>> validation = new ValidationResponse<List<Form>>();
            validation.Result = _context.Form.ToList();

            return validation;
        }

        public PaginationResponse<LanguageDTO> GetLanguages(PaginationRequestDTO? request)
        {
            PaginationResponse<LanguageDTO> validation = new PaginationResponse<LanguageDTO>(request);
            List<Language> result = _context.Language
                .OrderBy(item => item.Name)
                .Filter(request?.SearchPhrase)
                .ToList();

            validation.Paginate(result, (model) => new LanguageDTO(model));

            return validation;
        }

        public PaginationResponse<ProjectDTO> GetProjects(PaginationRequestDTO? request = null)
        {
            PaginationResponse<ProjectDTO> validation = new PaginationResponse<ProjectDTO>(request);
            List<Project> result = _context.Project
                .Include(item => item.Language)
                   .OrderBy(item => item.Name)
                   .Filter(request?.SearchPhrase)
                   .ToList();

            validation.Paginate(result, (model) => new ProjectDTO(model));

            return validation;
        }

        public PaginationResponse<PartOfSpeech> GetPartsOfSpeechByLanguage(PaginationRequestDTO? request, Guid projectID)
        {
            
            PaginationResponse<PartOfSpeech> validation = new PaginationResponse<PartOfSpeech>(request);
            validation.Result = _context.PartOfSpeech
                .Include(item => item.Project)
                .ToList();

            return validation;
        }

        public ValidationResponse<Form> GetFormById(Guid id)
        {
            ValidationResponse<Form> validation = new ValidationResponse<Form>();
            validation.Result = _context.Form.FirstOrDefault(x => x.ID == id);
            if (validation.Result == null)
            {
                validation.Errors.Add("No form with that ID");
            }

            return validation;
        }

        public ValidationResponse<Language> GetLanguageById(Guid id)
        {
            ValidationResponse<Language> validation = new ValidationResponse<Language>();
            validation.Result = _context.Language.FirstOrDefault(x => x.ID == id);
            if (validation.Result == null)
            {
                validation.Errors.Add("No language with that ID");
            }

            return validation;
        }

        public ValidationResponse<Project> GetProjectById(Guid id)
        {
            ValidationResponse<Project> validation = new ValidationResponse<Project>();
            validation.Result = _context.Project.FirstOrDefault(x => x.ID == id);
            if (validation.Result == null)
            {
                validation.Errors.Add("No project with that ID");
            }

            return validation;
        }

        public ValidationResponse<Project> GetProjectByCode(string code)
        {
            ValidationResponse<Project> validation = new ValidationResponse<Project>();
            validation.Result = _context.Project.FirstOrDefault(x => x.Code == code);
            if (validation.Result == null)
            {
                validation.Errors.Add("No project with that code");
            }

            return validation;

        }


        public ValidationResponse<PartOfSpeech> GetPartOfSpeechById(Guid id)
        {
            ValidationResponse<PartOfSpeech> validation = new ValidationResponse<PartOfSpeech>();
            validation.Result = _context.PartOfSpeech.FirstOrDefault(x => x.ID == id);
            if (validation.Result == null)
            {
                validation.Errors.Add("No part of speech with that ID");
            }

            return validation;
        }

        public ValidationResponse<List<PartOfSpeech>> GetPartsOfSpeechByLanguageCode(string code)
        {
            ValidationResponse<List<PartOfSpeech>> validation = new ValidationResponse<List<PartOfSpeech>>();
            validation.Result = _context.PartOfSpeech
                .Where(item => item.Project.Code == code)
                .ToList();

            if (validation.Result == null || !validation.Result.Any())
                validation.Notifications.Add("Search result is empty");

            return validation;
        }

        public ValidationResponse<List<Form>> GetFormsByPos(Guid posId)
        {
            ValidationResponse<List<Form>> validation = new ValidationResponse<List<Form>>();
            validation.Result = _context.Form
                .Where(item => item.PartOfSpeech.ID == posId)
                .ToList();

            return validation;
        }

        public PaginationResponse<PartOfSpeech> GetPartsOfSpeechByProject(PaginationRequestDTO? request, Project project)
        {
            PaginationResponse<PartOfSpeech> validation = new PaginationResponse<PartOfSpeech>(request);
            List<PartOfSpeech> result = _context.PartOfSpeech
                .Where(item => item.Project == project)
                .OrderBy(item => item.Name)
                .Filter(request?.SearchPhrase)
                .ToList();

            validation.Paginate(result);

            return validation;
        }
    }
}
