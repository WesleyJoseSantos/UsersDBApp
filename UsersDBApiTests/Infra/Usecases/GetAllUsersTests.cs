using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDBApi.Infra.Usecases.Users;
using UsersDBApiTests.Mocks;

namespace UsersDBApiTests.Infra.Usecases
{
    [TestClass]
    public class GetAllUsersTests
    {
        [TestMethod]
        public void MustReturnAllUsers()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new GetAllUsers(repository);
            var result = usecase.Handle();
            var users = result.RightOrDefault();
            
            Assert.IsTrue(result.IsRight);

            int i = 0;
            foreach (var user in users)
            {
                Assert.AreEqual(MockedData.Users[i].Name, user.Name);
                Assert.AreEqual(MockedData.Users[i].Email, user.Email);
                Assert.AreEqual(MockedData.Users[i].Phone, user.Phone);
                Assert.AreEqual(MockedData.Users[i].Password, user.Password);
                Assert.AreEqual(MockedData.Users[i].Level, user.Level);
                i++;
            }
        }
    }
}
