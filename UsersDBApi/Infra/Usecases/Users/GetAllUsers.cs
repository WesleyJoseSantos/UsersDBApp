using System.Collections.Generic;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Usecases.Users;
using UsersDBApi.Lib;
using UsersDBApi.Domain.repositories;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApi.Infra.Usecases.Users
{
    public class GetAllUsers : IGetAllUsers
    {
        private readonly IUsersRepository repository;

        public GetAllUsers(IUsersRepository repository)
        {
            this.repository = repository;
        }

        public Either<IBaseError, List<UserModel>> Handle()
        {
            try
            {
                return repository.GetAllUsers();
            }
            catch (System.Exception ex)
            {
                return new DatabaseExceptionError(ex.Message);
            }
        }
    }
}
