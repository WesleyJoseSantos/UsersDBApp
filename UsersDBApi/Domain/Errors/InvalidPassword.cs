using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public class InvalidPassword : IBaseError
    {
        public int ErrorCode => 0x7003;

        public string Title => "Erro";

        public string Message => $"A senha informada é inválida! (0x{ErrorCode.ToString("X4")})";
    }
}
