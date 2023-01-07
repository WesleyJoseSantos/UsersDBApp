namespace UsersDBApi.Domain.DTOs
{
    public enum UserLevel
    {
        None,
        User,
        Administrator
    }

    public class UserDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public UserLevel Level { get; set; }

        public UserDTO() { }

        public UserDTO(string name, string email, string phone, string password, UserLevel level)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
            Level = level;
        }
    }
}
