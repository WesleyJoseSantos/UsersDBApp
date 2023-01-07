namespace UsersDBApi.Domain.Errors
{
    public class IncorrectPasswordError : IBaseError
    {
        public int ErrorCode => 0x9000;

        public string Title => "Erro";

        public string Message => $"A senha informada é incorreta!! (0x{ErrorCode.ToString("X4")})";
    }
}
