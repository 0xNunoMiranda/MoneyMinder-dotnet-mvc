using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder_dotnet_mvc.Application.UseCases.Expenses.Register;
using MoneyMinder_dotnet_mvc.Communication.Requests;
using MoneyMinder_dotnet_mvc.Communication.Responses;

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
                var errorResponse = new ResponseError(ex.Message);
                return BadRequest(errorResponse);
            }
            catch
            {
                var errorResponse = new ResponseError("unkown error from API");
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

    }
}
