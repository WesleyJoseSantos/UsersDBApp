using System.Collections.Generic;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Usecases.Users;
using UsersDBApi.Lib;
using UsersDBApi.Domain.repositories;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApi.Infra.Usecases.Users
{
    public class GetUserByName : IGetUsersByName
    {
        private readonly IUsersRepository repository;

        public GetUserByName(IUsersRepository repository)
        {
            this.repository = repository;
        }

        public Either<IBaseError, List<UserModel>> Handle(string name)
        {
            try
            {
                return repository.GetUsersByName(name);
            }
            catch (System.Exception ex)
            {
                return new DatabaseExceptionError(ex.Message);
            }
        }
    }
}
