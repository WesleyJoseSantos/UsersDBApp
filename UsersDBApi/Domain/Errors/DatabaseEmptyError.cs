using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public class DatabaseEmptyError : IBaseError
    {
        public int ErrorCode => 0x8000;

        public string Title => "Erro";

        public string Message => $"O banco de dados está vazio! (0x{ErrorCode.ToString("X4")})";
    }
}
