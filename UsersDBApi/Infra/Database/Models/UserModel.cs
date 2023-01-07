using System;
using UsersDBApi.Domain.DTOs;

namespace UsersDBApi.Infra.Database.Models
{
    public class UserModel : UserDTO
    {
        public int Id { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public string DeletedAt { get; set; }

        public UserModel() { }

        public UserModel(string name, string email, string phone, string password, UserLevel level, string createdAt) : base(name, email, phone, password, level)
        {
            CreatedAt = createdAt;
        }

        static public UserModel Create(UserDTO user)
        {
            return new UserModel(user.Name, user.Email, user.Phone, user.Password, user.Level, DateTime.Now.ToString());
        }
    }
}
