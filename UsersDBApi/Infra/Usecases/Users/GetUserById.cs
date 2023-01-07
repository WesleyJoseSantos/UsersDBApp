using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.repositories;
using UsersDBApi.Domain.Usecases.Users;
using UsersDBApi.Lib;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApi.Infra.Usecases.Users
{
    public class GetUserById : IGetUserById
    {
        private readonly IUsersRepository repository;

        public GetUserById(IUsersRepository repository)
        {
            this.repository = repository;
        }

        public Either<IBaseError, UserModel> Handle(int id)
        {
            try
            {
                return repository.GetUserById(id);
            }
            catch (System.Exception ex)
            {
                return new DatabaseExceptionError(ex.Message);
            }
        }
    }
}
