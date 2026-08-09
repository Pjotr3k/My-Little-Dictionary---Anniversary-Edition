using Data;

namespace Service.Base
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
