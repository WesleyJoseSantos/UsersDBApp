using System.Collections.Generic;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Lib;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApi.Domain.Usecases.Users
{
    public interface IGetAllUsers
    {
        Either<IBaseError, List<UserModel>> Handle();
    }
}
