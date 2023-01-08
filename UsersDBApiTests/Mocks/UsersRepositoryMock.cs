using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.repositories;
using UsersDBApi.Infra.Database.Models;
using UsersDBApi.Lib;

namespace UsersDBApiTests.Mocks
{
    public class UsersRepositoryMock : IUsersRepository
    {
        public Either<IBaseError, UserModel> CreateUser(UserDTO user)
        {
            var newUser = UserModel.Create(user);
            MockedData.Users.Add(newUser);
            return newUser;
        }

        public Either<IBaseError, List<UserModel>> GetAllUsers()
        {
            return MockedData.Users;
        }

        public Either<IBaseError, UserModel> GetUserByEmail(string email)
        {
            var result = MockedData.Users.Find(item => item.Email == email);
            return result == null ? new EmailNotFoundError() : result;
        }

        public Either<IBaseError, UserModel> GetUserById(int id)
        {
            var result = MockedData.Users.Find(item => item.Id == id);
            return result == null ? new IdNotFoundError() : result;
        }

        public Either<IBaseError, List<UserModel>> GetUsersByName(string name)
        {
            var result = MockedData.Users.FindAll(item => item.Name.Contains(name));
            return result == null || result.Count == 0 ? new NameNotFoundError() : result;
        }
    }
}
