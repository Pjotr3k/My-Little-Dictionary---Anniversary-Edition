using Domain;
using Service.DTOs;
using System.Linq.Expressions;

namespace Service.Interfaces
{
    public interface IProjectService
    {
        Project AddProject(ProjectInsertDTO request);
        Project GetProjectById(Guid id, params Expression<Func<Project, object>>[] includeFuncs);
        Project GetProjectByCode(string code);
        IQueryable<Project> GetProjects();
    }
}
