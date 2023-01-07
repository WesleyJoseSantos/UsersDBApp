using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public class InvalidNameError : IBaseError
    {
        public int ErrorCode => 0x7000;

        public string Title => "Erro";

        public string Message => $"O nome informado é inválido! (0x{ErrorCode.ToString("X4")})";
    }
}
