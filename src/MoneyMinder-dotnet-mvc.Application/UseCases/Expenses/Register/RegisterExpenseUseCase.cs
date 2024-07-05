using MoneyMinder_dotnet_mvc.Communication.Requests;
using MoneyMinder_dotnet_mvc.Communication.Responses;

namespace MoneyMinder_dotnet_mvc.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseRegisteredExpense Execute(RequestRegisterExpense request)
        {
            return new ResponseRegisteredExpense();
        }
    }
}
