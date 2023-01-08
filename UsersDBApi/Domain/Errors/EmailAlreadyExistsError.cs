using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public class EmailAlreadyExistsError : IBaseError
    {
        public int ErrorCode => 0x6001;

        public string Title => "Erro";

        public string Message => $"O email informado já existe na base de dados! (0x{ErrorCode.ToString("X4")})";
    }
}
