using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Errors;

namespace UsersDBApi.Domain.Usecases.Users
{
    public interface IGenerateReport
    {
        IBaseError Handle(UserDTO user, Document document, string path, string titleText);
    }
}
