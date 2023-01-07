using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.Errors
{
    public interface IBaseError
    {
        int ErrorCode { get; }
        string Title { get; }
        string Message { get; }
    }
}
