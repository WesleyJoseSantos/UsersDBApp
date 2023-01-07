using System.Collections.Generic;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Lib;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApi.Domain.repositories
{
    public interface IUsersRepository
    {
        Either<IBaseError, UserModel> CreateUser(UserDTO user);

        Either<IBaseError, UserModel> GetUserByEmail(string email);

        Either<IBaseError, List<UserModel>> GetAllUsers();

        Either<IBaseError, UserModel> GetUserById(int id);

        Either<IBaseError, List<UserModel>> GetUsersByName(string name);
    }
}
