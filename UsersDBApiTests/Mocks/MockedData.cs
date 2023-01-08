using UsersDBApi.Domain.DTOs;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApiTests.Mocks
{
    internal class MockedData
    {
        static public List<UserModel> Users => new List<UserModel>
        {
            new UserModel("Mocker User", "mocker@mail.com", "37555555", "password", UserLevel.Administrator, DateTime.Now.ToString()),
            new UserModel("João Paulo", "joao@mail.com", "3712345678", "joaopass", UserLevel.User, DateTime.Now.ToString()),
            new UserModel("Paulo Silva", "paulo@mail.com", "3711223344", "paulopass", UserLevel.User, DateTime.Now.ToString()),
        };

        static public UserDTO UserInvalidName => new UserDTO("", "user@mail.com.br", "3732144331", "password", UserLevel.None);
        
        static public UserDTO UserInvalidEmail => new UserDTO("user name", "email.com.br", "3732144331", "password", UserLevel.None);

        static public UserDTO UserInvalidPhone => new UserDTO("user name", "user@mail.com.br", "37-32144331", "password", UserLevel.None);

        static public UserDTO UserInvalidPassword => new UserDTO("user name", "user@mail.com.br", "3732144331", "", UserLevel.None);
    
        static public UserDTO NewUser => new UserDTO("new user", "newuser@mail.com.br", "3732144331", "newuserpass", UserLevel.None);

        static public UserCredentialsDTO UserCredentialsInexistentEmail => new UserCredentialsDTO("inexistent", "inexistent");

        static public UserCredentialsDTO UserCredentials = new UserCredentialsDTO("joao@mail.com", "joaopass");

        static public UserCredentialsDTO UserCredentialsIncorrectPassword = new UserCredentialsDTO("joao@mail.com", "incorrect pass");
    }
}
