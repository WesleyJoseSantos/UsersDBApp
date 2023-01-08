using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Infra.Usecases.Users;
using UsersDBApiTests.Mocks;

namespace UsersDBApiTests.Infra.Usecases
{
    [TestClass]
    public class CreateUserTests
    {
        [TestMethod]
        public void MustReturnInvalidNameError()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new CreateUser(repository);
            var result = usecase.Handle(MockedData.UserInvalidName);

            Assert.IsTrue(result.IsLeft);
            Assert.IsTrue(result.LeftOrDefault() is InvalidNameError);
        }

        [TestMethod]
        public void MustReturnInvalidEmailError()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new CreateUser(repository);
            var result = usecase.Handle(MockedData.UserInvalidEmail);

            Assert.IsTrue(result.IsLeft);
            Assert.IsTrue(result.LeftOrDefault() is InvalidEmailError);
        }

        [TestMethod]
        public void MustReturnInvalidPhoneNumber()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new CreateUser(repository);
            var result = usecase.Handle(MockedData.UserInvalidPhone);

            Assert.IsTrue(result.IsLeft);
            Assert.IsTrue(result.LeftOrDefault() is InvalidPhoneNumberError);
        }

        [TestMethod]
        public void MustReturnInvalidPasswordError()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new CreateUser(repository);
            var result = usecase.Handle(MockedData.UserInvalidPassword);

            Assert.IsTrue(result.IsLeft);
            Assert.IsTrue(result.LeftOrDefault() is InvalidPasswordError);
        }

        [TestMethod]
        public void MustReturnCreatedUser()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new CreateUser(repository);
            var result = usecase.Handle(MockedData.NewUser);

            Assert.IsTrue(result.IsRight);
            Assert.AreEqual(result.RightOrDefault().Name, MockedData.NewUser.Name);
            Assert.AreEqual(result.RightOrDefault().Email, MockedData.NewUser.Email);
            Assert.AreEqual(result.RightOrDefault().Phone, MockedData.NewUser.Phone);
            Assert.AreEqual(result.RightOrDefault().Password, MockedData.NewUser.Password);
            Assert.AreEqual(result.RightOrDefault().Level, MockedData.NewUser.Level);
        }
    }
}
