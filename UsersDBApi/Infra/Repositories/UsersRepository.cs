using System.Collections.Generic;
using System.Data;
using System.Linq;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.repositories;
using UsersDBApi.Lib;
using Dapper;
using UsersDBApi.Infra.Database.Models;
using UsersDBApi.Domain.Database;

namespace UsersDBApi.Infra.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private IConnection connection;

        public UsersRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public Either<IBaseError, UserModel> CreateUser(UserDTO user)
        {
            using (IDbConnection db = connection.Get("usersdb"))
            {
                var model = UserModel.Create(user);

                var name = db.Query<UserDTO>($"SELECT * FROM users WHERE Name = '{user.Name}'");
                if(name.Count() > 0 )
                {
                    return new NameAlreadyExistsError();
                }

                var email = db.Query<UserModel>($"SELECT * FROM users WHERE Email = '{user.Email}'");
                if(email.Count() > 0 )
                {
                    return new EmailAlreadyExistsError();
                }

                db.Execute($"INSERT INTO users (Name, Email, Phone, Password, Level, CreatedAt) Values(@Name, @Email, @Phone, @Password, @Level, @CreatedAt)", model);
                return model;
            }
        }

        public Either<IBaseError, List<UserModel>> GetAllUsers()
        {
            using (IDbConnection db = connection.Get("usersdb"))
            {
                var result = db.Query<UserModel>($"SELECT * FROM users");
                if(result.Count() > 0)
                {
                    return result.ToList();
                }
                else
                {
                    return new DatabaseEmptyError();
                }
            }
        }

        public Either<IBaseError, UserModel> GetUserByEmail(string email)
        {
            using (IDbConnection db = connection.Get("usersdb"))
            {
                var result = db.Query<UserModel>($"SELECT * FROM users WHERE Email = '{email}'");
                if(result.Count() > 0)
                {
                    return result.First();
                }
                else
                {
                    return new EmailNotFoundError();
                }
            }
        }

        public Either<IBaseError, UserModel> GetUserById(int id)
        {
            using (IDbConnection db = connection.Get("usersdb"))
            {
                var result = db.Query<UserModel>($"SELECT * FROM users WHERE Id = {id}");
                if (result.Count() > 0)
                {
                    return result.First();
                }
                else
                {
                    return new IdNotFoundError();
                }
            }
        }

        public Either<IBaseError, List<UserModel>> GetUsersByName(string name)
        {
            using (IDbConnection db = connection.Get("usersdb"))
            {
                var result = db.Query<UserModel>($"SELECT * FROM users WHERE CHARINDEX('{name}', Name) > 0");
                if (result.Count() > 0)
                {
                    return result.ToList();
                }
                else
                {
                    return new NameNotFoundError();
                }
            }
        }
    }
}
