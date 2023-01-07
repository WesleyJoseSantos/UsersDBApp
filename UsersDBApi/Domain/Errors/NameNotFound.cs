using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public class NameNotFoundError : IBaseError
    {
        public int ErrorCode => 0x8003;

        public string Title => "Erro";

        public string Message => $"O nome informado não foi encontrado! (0x{ErrorCode.ToString("X4")})";
    }
}
