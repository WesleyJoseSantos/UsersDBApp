using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDBApi.Domain.DTOs
{
    public class UserCredentialsDTO
    {
        public string Email { get; set;}

        public string Password { get; set;}

        public UserCredentialsDTO(string userName, string password)
        {
            Email = userName;
            Password = password;
        }
    }
}
