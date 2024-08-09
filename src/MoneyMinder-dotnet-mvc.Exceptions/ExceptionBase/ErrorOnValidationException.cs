namespace MoneyMinder_dotnet_mvc.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : CashFlowException
    {
        public List<string> ErrorsMessages { get; set; } = [];
        public ErrorOnValidationException(List<string> errorMessages)
        {
            ErrorsMessages = errorMessages;
        }

    }
}
