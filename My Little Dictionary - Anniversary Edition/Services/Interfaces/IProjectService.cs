using My_Little_Dictionary___Anniversary_Edition.DTOs;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Interfaces
{
    public interface IProjectService
    {
        Project AddProject(ProjectInsertDTO request);
        Project GetProjectById(Guid id);
        Project GetProjectByCode(string code);
        PaginationResult<Project> GetProjects(PaginationRequest? request = null);
    }
}
