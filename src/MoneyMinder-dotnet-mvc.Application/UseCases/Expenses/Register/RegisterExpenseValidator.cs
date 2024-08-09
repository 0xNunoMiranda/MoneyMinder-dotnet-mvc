using FluentValidation;
using MoneyMinder_dotnet_mvc.Communication.Requests;
using MoneyMinder_dotnet_mvc.Exceptions;

namespace MoneyMinder_dotnet_mvc.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpense>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
            
            RuleFor(expense => expense.Amount)
                .GreaterThan(0)
                .LessThan(999999)
                .WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);

            RuleFor(expense => expense.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE);

            RuleFor(expense => expense.PaymentType)
                .IsInEnum()
                .WithMessage(ResourceErrorMessages.PAYMENTS_TYPE_INVALID);
        }
    }
}
