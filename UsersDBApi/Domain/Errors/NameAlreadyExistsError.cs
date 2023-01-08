using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public class NameAlreadyExistsError : IBaseError
    {
        public int ErrorCode => 0x6000;

        public string Title => "Erro";

        public string Message => $"O nome informado já existe na base de dados! (0x{ErrorCode.ToString("X4")})";
    }
}
