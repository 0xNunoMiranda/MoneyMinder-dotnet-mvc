using Bogus;
using MoneyMinder_dotnet_mvc.Communication.Enums;
using MoneyMinder_dotnet_mvc.Communication.Requests;
using System.ComponentModel.DataAnnotations;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterExpenseBuilder
    {
        public static RequestRegisterExpense Build()
        {
            return new Faker<RequestRegisterExpense>()
                .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
                .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
                .RuleFor(r => r.Date, faker => faker.Date.Past())
                .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
                .RuleFor(r => r.Amount, faker => faker.Random.Decimal( min:1,max:99999))
                ;
                
        }

    }
}
