namespace MoneyMinder_dotnet_mvc.Communication.Responses
{
    public class ResponseError
    {
        public List<string> ErrorMessage { get; set; } = [];

        public ResponseError(string errorMessage)
        {
            ErrorMessage.Add(errorMessage);
        }

        public ResponseError(List<string> errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
