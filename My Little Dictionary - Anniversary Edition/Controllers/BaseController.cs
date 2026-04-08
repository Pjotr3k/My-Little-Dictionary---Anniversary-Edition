using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Little_Dictionary___Anniversary_Edition.Data;
using My_Little_Dictionary___Anniversary_Edition.Validation;
using System.Diagnostics;

namespace My_Little_Dictionary___Anniversary_Edition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        private readonly ApplicationDBContext _context;

        public BaseController(ILogger<BaseController> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected ActionResult ResponseWithValidationResponse<T>(Func<T> callback)
        {
            ValidationResponse<T> result = new ValidationResponse<T>();

            Stopwatch stopwatch = Stopwatch.StartNew();

            using var transaction = _context.Database.BeginTransaction();

            _logger.LogInformation($"Operation called");

            try
            {
                result.Result = callback.Invoke();

                _logger.LogInformation($"Commiting transaction after {stopwatch.Elapsed}");
                transaction.Commit();

                _logger.LogInformation($"Operation finnished succesfully after {stopwatch.Elapsed}");
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                result.Errors.AddRange(ex.Errors);

                _logger.LogError(ex.Message);
                foreach (var error in ex.Errors)
                {
                    _logger.LogError(error);
                }

                _logger.LogInformation($"Rolling back changes after {stopwatch.Elapsed}");
                transaction.Rollback();

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Errors.Add("Unknown error");
                _logger.LogError(ex.Message);

                _logger.LogInformation($"Rolling back changes after {stopwatch.Elapsed}");
                transaction.Rollback();

                return Ok(result);
            }
        }
        protected async Task<ActionResult> ResponseWithValidationResponseAsync<T>(Func<Task<T>> callback)
        {
            ValidationResponse<T> result = new ValidationResponse<T>();

            Stopwatch stopwatch = Stopwatch.StartNew();

            using var transaction = await _context.Database.BeginTransactionAsync();

            _logger.LogInformation($"Operation called");

            try
            {
                result.Result = await callback.Invoke();

                _logger.LogInformation($"Commiting transaction after {stopwatch.Elapsed}");
                await transaction.CommitAsync();

                _logger.LogInformation($"Operation finnished succesfully after {stopwatch.Elapsed}");
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                result.Errors.AddRange(ex.Errors);

                _logger.LogError(ex.Message);
                foreach (var error in ex.Errors)
                {
                    _logger.LogError(error);
                }

                _logger.LogInformation($"Rolling back changes after {stopwatch.Elapsed}");
                await transaction.RollbackAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Errors.Add("Unknown error");
                _logger.LogError(ex.Message);

                _logger.LogInformation($"Rolling back changes after {stopwatch.Elapsed}");
                await transaction.RollbackAsync();

                return Ok(result);
            }
        }
    }
}
