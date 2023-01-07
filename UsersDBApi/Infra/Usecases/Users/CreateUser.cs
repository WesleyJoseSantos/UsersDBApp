using System;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.repositories;
using UsersDBApi.Domain.Usecases.Users;
using UsersDBApi.Lib;
using UsersDBApi.Infra.Database.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace UsersDBApi.Infra.Usecases.Users
{
    public class CreateUser : ICreateUser
    {
        private IUsersRepository repository;

        public CreateUser(IUsersRepository repository)
        {
            this.repository = repository;
        }

        public Either<IBaseError, UserModel> Handle(UserDTO user)
        {
            if(user.Name == null || user.Name == "")
            {
                return new InvalidNameError();
            }

            try
            {
                new MailAddress(user.Email);
            }
            catch (Exception)
            {
                return new InvalidEmailError();
            }

            var phoneRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
            if (user.Phone == null || !phoneRegex.IsMatch(user.Phone)) 
            {
                return new InvalidPhoneNumber();
            }

            if(user.Password == null || user.Password.Length < 8) 
            {
                return new InvalidPassword();
            }

            try
            {
                return repository.CreateUser(user);
            }
            catch (System.Exception ex)
            {
                return new DatabaseExceptionError(ex.Message);
            }

        }
    }
}
