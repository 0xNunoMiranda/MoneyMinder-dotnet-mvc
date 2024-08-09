using MoneyMinder_dotnet_mvc.Communication.Requests;
using MoneyMinder_dotnet_mvc.Communication.Responses;
using MoneyMinder_dotnet_mvc.Exceptions.ExceptionBase;

namespace MoneyMinder_dotnet_mvc.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpense Execute(RequestRegisterExpense request)
    {
        Validate(request);
        return new ResponseRegisteredExpense();
    }
    
    
    private void Validate(RequestRegisterExpense request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);


        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
         
            throw new ErrorOnValidationException(errorMessages);
        }

    } 

}
