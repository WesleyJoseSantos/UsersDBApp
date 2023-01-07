namespace UsersDBApi.Domain.Errors
{
    public class DatabaseExceptionError : IBaseError
    {
        private string message;

        public int ErrorCode => 0x5000;

        public string Title => "Erro no Banco de Dados";

        public string Message => message;

        public DatabaseExceptionError(string message)
        {
            this.message = $"{message} (0x{ErrorCode.ToString("X4")})"; ;
        }
    }
}
