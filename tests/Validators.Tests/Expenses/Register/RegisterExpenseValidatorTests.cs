using CommonTestUtilities.Requests;
using FluentAssertions;
using MoneyMinder_dotnet_mvc.Application.UseCases.Expenses.Register;
using MoneyMinder_dotnet_mvc.Communication.Requests;
using MoneyMinder_dotnet_mvc.Exceptions;
using Xunit;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTests
    {
        [Fact]
        public void Success()
        {
            //Arrange - Configurar as instancias que precisamos para iniciar o test
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseBuilder.Build();
            
            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Error_Title_Empty()
        {
            //Arrange - Configurar as instancias que precisamos para iniciar o test
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseBuilder.Build();
            request.Title = string.Empty;

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(
                equals => equals.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED)
                );
        }

    }
}
