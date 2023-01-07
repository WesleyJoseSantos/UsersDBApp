using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public class NoError : IBaseError
    {
        public int ErrorCode => 0x0;

        public string Title => "Sucesso";

        public string Message => $"Operação executada com sucesso! (0x{ErrorCode.ToString("X4")})";
    }
}
