using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
         public async Task<ActionResult> ResponseBase<T>(Task<T> func) where T : class
        {
            if (await func != null)
            {
                return Ok(func.Result);
            }
            else
            {
                return NotFound();
            }
        }
        public async Task<ActionResult> ResponseBase(Task func)
        {
            await func;
            return Ok();
        }
    }
}
