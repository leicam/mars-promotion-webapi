using Microsoft.AspNetCore.Mvc;

namespace Mars.Promocao.Apresentacao.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        protected async Task<IActionResult> InvokeMethosAsync<T, TResult>(Func<T, Task<TResult>> method, T args)
        {
            try
            {
                return Ok(await method.Invoke(args));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}