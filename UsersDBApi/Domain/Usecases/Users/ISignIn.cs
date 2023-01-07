using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Infra.Database.Models;
using UsersDBApi.Lib;

namespace UsersDBApi.Domain.Usecases.Users
{
    public interface ISignIn
    {
        Either<IBaseError, UserModel> Handle(UserCredentialsDTO credentials);
    }
}
