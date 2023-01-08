using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public class InvalidPhoneNumberError : IBaseError
    {
        public int ErrorCode => 0x7002;

        public string Title => "Erro";

        public string Message => $"O número de telefone informado é inválido! (0x{ErrorCode.ToString("X4")})";
    }
}
