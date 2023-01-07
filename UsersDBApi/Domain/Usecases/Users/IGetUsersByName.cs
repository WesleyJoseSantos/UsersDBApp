using System.Collections.Generic;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Lib;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApi.Domain.Usecases.Users
{
    public interface IGetUsersByName
    {
        Either<IBaseError, List<UserModel>> Handle(string name);
    }
}
