using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public class InvalidEmailError : IBaseError
    {
        public int ErrorCode => 0x7001;

        public string Title => "Erro";

        public string Message => $"O email informado é inválido! (0x{ErrorCode.ToString("X4")})";
    }
}
