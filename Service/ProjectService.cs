using Data;
using Domain;
using Service.Base;
using Service.DTOs;
using Service.Interfaces;
using Service.Validation;
using System.Linq.Expressions;

namespace Service
{
    public class ProjectService : BaseContextService, IProjectService
    {
        private readonly ILanguageService _languageService;

        public ProjectService(ILanguageService languageService, ApplicationDBContext context) : base(context)
        {
            _languageService = languageService;
        }

        public Project AddProject(ProjectInsertDTO request)
        {
            var language = _languageService
                .GetLanguageById(request.BaseLanguage)
                .ValidateOnNull(request.BaseLanguage, "Language");

            Project project = new Project();

            request.GetData(project);

            _context.Add(project);
            _context.SaveChanges();

            return project;
        }
            
        public Project GetProjectById(Guid id, params Expression<Func<Project, object>>[] includeFuncs)
            => _context.Project.GetById(id, includeFuncs);

        public Project GetProjectByCode(string code)
            => _context.Project.FirstOrDefault(x => x.Code == code);

        public IQueryable<Project> GetProjects()
            => _context.Project;
    }
}
