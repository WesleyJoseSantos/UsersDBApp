using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Usecases.Users;
using UsersDBApi.Lib;
using UsersDBApi.Domain.repositories;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApi.Infra.Usecases.Users
{
    public class GetUserByEmail : IGetUserByEmail
    {
        private readonly IUsersRepository repository;

        public GetUserByEmail(IUsersRepository repository)
        {
            this.repository = repository;
        }

        public Either<IBaseError, UserModel> Handle(string email)
        {
            try
            {
                return repository.GetUserByEmail(email);
            }
            catch (System.Exception ex)
            {
                return new DatabaseExceptionError(ex.Message);
            }
        }
    }
}
