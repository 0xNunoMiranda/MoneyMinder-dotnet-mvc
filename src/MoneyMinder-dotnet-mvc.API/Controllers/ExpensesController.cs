using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder_dotnet_mvc.Application.UseCases.Expenses.Register;
using MoneyMinder_dotnet_mvc.Communication.Requests;

namespace MoneyMinder_dotnet_mvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpense request)
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }catch(ArgumentException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "unknown error from API");
            }
        }

    }
}
