using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;
using System.Linq.Expressions;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface IProjectService
    {
        Project AddProject(ProjectInsertDTO request);
        Project GetProjectById(Guid id, params Expression<Func<Project, object>>[] includeFuncs);
        Project GetProjectByCode(string code);
        IQueryable<Project> GetProjects();
    }
}
