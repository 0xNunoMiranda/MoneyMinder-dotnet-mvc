using MoneyMinder_dotnet_mvc.Communication.Enums;
using MoneyMinder_dotnet_mvc.Communication.Requests;
using MoneyMinder_dotnet_mvc.Communication.Responses;

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
        var titleIsEmpty = string.IsNullOrEmpty(request.Title);
        if (titleIsEmpty) throw new ArgumentException("The title is required");

        if (request.Amount <= 0) throw new ArgumentException("The Amount must be greater than zero.");


        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (result > 0) throw new ArgumentException("Expenses cannot be for the future");
        
        //Enum.isDefined valida o range dos valores estipulados. Caso o valor do input esteja fora dos valores
        //estipulados no Enum, então irá devolver FALSE.
        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType),request.PaymentType);
        if (!paymentTypeIsValid) throw new ArgumentException("Payment Type is not valid");


    } 

}
