using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Lib;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApi.Domain.Usecases.Users
{
    public interface IGetUserById
    {
        Either<IBaseError, UserModel> Handle(int id);
    }
}
