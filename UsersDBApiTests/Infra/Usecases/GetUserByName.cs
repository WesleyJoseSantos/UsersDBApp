using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Infra.Usecases.Users;
using UsersDBApiTests.Mocks;

namespace UsersDBApiTests.Infra.Usecases
{
    [TestClass]
    public class GetUserByNameTest
    {
        [TestMethod]
        public void MustReturnUser()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new GetUserByName(repository);
            var result = usecase.Handle(MockedData.Users[0].Name);
            var users = result.RightOrDefault();

            Assert.IsTrue(result.IsRight);
            Assert.IsTrue(users.Count() == 1);

            Assert.AreEqual(MockedData.Users[0].Name, users.First().Name);
            Assert.AreEqual(MockedData.Users[0].Email, users.First().Email);
            Assert.AreEqual(MockedData.Users[0].Phone, users.First().Phone);
            Assert.AreEqual(MockedData.Users[0].Password, users.First().Password);
            Assert.AreEqual(MockedData.Users[0].Level, users.First().Level);
        }

        [TestMethod]
        public void MustReturnEmailNotFound()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new GetUserByName(repository);
            var result = usecase.Handle("Inexistent Name");

            Assert.IsTrue(result.IsLeft);
            Assert.IsTrue(result.LeftOrDefault() is NameNotFoundError);
        }
    }
}
