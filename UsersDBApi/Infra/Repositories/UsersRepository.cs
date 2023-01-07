using System.Collections.Generic;
using System.Data;
using System.Linq;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.repositories;
using UsersDBApi.Infra.Database;
using UsersDBApi.Lib;
using Dapper;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApi.Infra.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public Either<IBaseError, UserModel> CreateUser(UserDTO user)
        {
            using (IDbConnection db = Connection.Get("usersdb"))
            {
                var model = UserModel.Create(user);

                var name = db.Query<UserDTO>($"SELECT * FROM users WHERE Name = '{user.Name}'");
                if(name.Count() > 0 )
                {
                    return new NameAlreadyExists();
                }

                var email = db.Query<UserModel>($"SELECT * FROM users WHERE Email = '{user.Email}'");
                if(email.Count() > 0 )
                {
                    return new EmailAlreadyExists();
                }

                db.Execute($"INSERT INTO users (Name, Email, Phone, Password, Level, CreatedAt) Values(@Name, @Email, @Phone, @Password, @Level, @CreatedAt)", model);
                return model;
            }
        }

        public Either<IBaseError, List<UserModel>> GetAllUsers()
        {
            using (IDbConnection db = Connection.Get("usersdb"))
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
            using (IDbConnection db = Connection.Get("usersdb"))
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
            using (IDbConnection db = Connection.Get("usersdb"))
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
            using (IDbConnection db = Connection.Get("usersdb"))
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
