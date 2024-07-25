using Microsoft.EntityFrameworkCore;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Interfaces;
using My_Little_Dictionary___Anniversary_Edition.Model;
using My_Little_Dictionary___Anniversary_Edition.Services.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Services
{
    public class LinguisticsService : BaseContextService, ILinguisticsService
    {
        public LinguisticsService(ApplicationDBContext context) : base(context)
        {

        }
        public ValidationResponse<Form> AddForm(FormInsertDTO request)
        {
            ValidationResponse<Form> validation = new ValidationResponse<Form>();

            PartOfSpeech pos = _context.PartOfSpeech.FirstOrDefault(x => x.ID == request.PartOfSpeech);

            if (pos == null)
            {
                validation.Errors.Add(string.Format("No part of speach with id {0}", request.PartOfSpeech.ToString()));
                return validation;
            }

            Form form = new Form()
            {
                Name = request.Name,
                Description = request.Description != null ? request.Description : "",
                PartOfSpeech = pos
            };

            _context.Add(form);
            _context.SaveChanges();
            validation.Result = form;

            return validation;
        }

        public ValidationResponse<Language> AddLanguage(LanguageInsertDTO request)
        {
            ValidationResponse<Language> validation = new ValidationResponse<Language>();

            Language language = new Language(request.Name, request.Description);

            _context.Add(language);
            _context.SaveChanges();
            validation.Result = language;

            return validation;
        }

        public ValidationResponse<PartOfSpeech> AddPartOfSpeech(PartOfSpeechInsertDTO request)
        {
            ValidationResponse<PartOfSpeech> validation = new ValidationResponse<PartOfSpeech>();

            Language language = _context.Language.FirstOrDefault(x => x.ID == request.Language);

            if (language == null)
            {
                validation.Errors.Add(string.Format("No language with id {0}", request.Language.ToString()));
                return validation;
            }

            PartOfSpeech pos = new PartOfSpeech()
            {
                Name = request.Name,
                Description = request.Description != null ? request.Description : "",
                Language = language,
                Forms = ""
            };

            _context.Add(pos);
            _context.SaveChanges();
            validation.Result = pos;

            return validation;

        }

        public ValidationResponse<List<Form>> BulkAddForm(List<FormInsertDTO> request)
        {
            ValidationResponse<List<Form>> validation = new ValidationResponse<List<Form>>();
            List<Form> forms = new List<Form>();

            foreach (var item in request)
            {
                PartOfSpeech pos = _context.PartOfSpeech.FirstOrDefault(x => x.ID == item.PartOfSpeech);

                if (pos == null)
                {
                    validation.Errors.Add(string.Format("No part of speach with id {0}", item.PartOfSpeech.ToString()));
                    continue;
                }

                Form form = new Form()
                {
                    Name = item.Name,
                    Description = item.Description != null ? item.Description : "",
                    PartOfSpeech = pos
                };

                forms.Add(form);
            }

            if (validation.Errors.Any()) return validation;

            _context.AddRange(forms);
            _context.SaveChanges();
            validation.Result = forms;

            return validation;
        }

        public ValidationResponse<List<Form>> GetAllForms()
        {
            ValidationResponse<List<Form>> validation = new ValidationResponse<List<Form>>();
            validation.Result = _context.Form.ToList();

            return validation;
        }

        public ValidationResponse<List<Language>> GetAllLanguages()
        {
            ValidationResponse<List<Language>> validation = new ValidationResponse<List<Language>>();
            validation.Result = _context.Language.ToList();

            return validation;
        }

        public ValidationResponse<List<PartOfSpeech>> GetAllPartsOfSpeech()
        {
            ValidationResponse<List<PartOfSpeech>> validation = new ValidationResponse<List<PartOfSpeech>>();
            validation.Result = _context.PartOfSpeech
                .Include(item => item.Language)
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
                .Where(item => item.Language.Code == code)
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
    }
}
