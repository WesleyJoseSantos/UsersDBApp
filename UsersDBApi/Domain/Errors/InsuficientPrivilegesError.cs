namespace UsersDBApi.Domain.Errors
{
    public class InsuficientPrivileges : IBaseError
    {
        public int ErrorCode => 0x9001;

        public string Title => "Erro";

        public string Message => $"O usuário não possui os privilégios necessários! (0x{ErrorCode.ToString("X4")})";
    }
}
