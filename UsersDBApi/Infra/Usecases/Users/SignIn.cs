using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.Usecases.Users;
using UsersDBApi.Infra.Database.Models;
using UsersDBApi.Lib;

namespace UsersDBApi.Infra.Usecases.Users
{
    public class SignIn : ISignIn
    {
        public IGetUserByEmail getUserByEmail;

        public SignIn(IGetUserByEmail getUserByEmail)
        {
            this.getUserByEmail = getUserByEmail;
        }

        public Either<IBaseError, UserModel> Handle(UserCredentialsDTO credentials)
        {
            try
            {
                var result = getUserByEmail.Handle(credentials.Email);
                if (result.IsLeft)
                {
                    return result.LeftOrDefault() as dynamic;
                }
                else
                {
                    var user = result.RightOrDefault();
                    if(credentials.Password == user.Password)
                    {
                        return user;
                    }
                    else
                    {
                        return new IncorrectPasswordError();
                    }
                }
            }
            catch (System.Exception ex)
            {
                return new DatabaseExceptionError(ex.Message);
            }

        }
    }
}
