using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Infra.Database.Models;

namespace UsersDBApiTests.Infra.Database.Models
{
    [TestClass]
    public class UserModelTests
    {
        [TestMethod]
        public void CreateMustReturnUserModel()
        {
            var user = new UserDTO("username", "user@email.com", "3799034578", "userpass", UserLevel.Administrator);

            var result = UserModel.Create(user);

            Assert.AreEqual(user.Name, result.Name);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual(user.Phone, result.Phone);
            Assert.AreEqual(user.Password, result.Password);
            Assert.AreEqual(user.Level, result.Level);
        }
    }
}
