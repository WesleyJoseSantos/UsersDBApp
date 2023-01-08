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
    public class SignInTests
    {
        [TestMethod]
        public void MustReturnEmailNotFoundError()
        {
            var repository = new UsersRepositoryMock();
            var getUserByEmail = new GetUserByEmail(repository);
            var usecase = new SignIn(getUserByEmail);
            var result = usecase.Handle(MockedData.UserCredentialsInexistentEmail);

            Assert.IsTrue(result.IsLeft);
            Assert.IsTrue(result.LeftOrDefault() is EmailNotFoundError);
        }

        [TestMethod]
        public void MustReturUserModel()
        {
            var repository = new UsersRepositoryMock();
            var getUserByEmail = new GetUserByEmail(repository);
            var usecase = new SignIn(getUserByEmail);
            var result = usecase.Handle(MockedData.UserCredentials);

            var expectedUser = getUserByEmail.Handle(MockedData.UserCredentials.Email).RightOrDefault();
            var user = result.RightOrDefault();

            Assert.IsTrue(result.IsRight);
            Assert.AreEqual(expectedUser.Name, user.Name);
            Assert.AreEqual(expectedUser.Email, user.Email);
            Assert.AreEqual(expectedUser.Phone, user.Phone);
            Assert.AreEqual(expectedUser.Password, user.Password);
            Assert.AreEqual(expectedUser.Level, user.Level);
        }

        [TestMethod]
        public void MustNotReturIncorrectPasswordError()
        {
            var repository = new UsersRepositoryMock();
            var getUserByEmail = new GetUserByEmail(repository);
            var usecase = new SignIn(getUserByEmail);
            var result = usecase.Handle(MockedData.UserCredentialsIncorrectPassword);

            Assert.IsTrue(result.IsLeft);
            Assert.IsTrue(result.LeftOrDefault() is IncorrectPasswordError);
        }
    }
}
