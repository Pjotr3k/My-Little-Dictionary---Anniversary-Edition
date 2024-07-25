using My_Little_Dictionary___Anniversary_Edition.Data;

namespace My_Little_Dictionary___Anniversary_Edition.Services.Base
{
    public abstract class BaseContextService
    {
        protected readonly ApplicationDBContext _context;
        protected BaseContextService(ApplicationDBContext context)
        {
            _context = context;
        }
    }
}
