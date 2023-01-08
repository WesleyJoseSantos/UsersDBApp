﻿using System;
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
    public class GetUserByEmailTest
    {
        [TestMethod]
        public void MustReturnUser()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new GetUserByEmail(repository);
            var result = usecase.Handle(MockedData.Users[0].Email);
            var user = result.RightOrDefault();

            Assert.IsTrue(result.IsRight);

            Assert.AreEqual(MockedData.Users[0].Name, user.Name);
            Assert.AreEqual(MockedData.Users[0].Email, user.Email);
            Assert.AreEqual(MockedData.Users[0].Phone, user.Phone);
            Assert.AreEqual(MockedData.Users[0].Password, user.Password);
            Assert.AreEqual(MockedData.Users[0].Level, user.Level);
        }

        [TestMethod]
        public void MustReturnEmailNotFound()
        {
            var repository = new UsersRepositoryMock();
            var usecase = new GetUserByEmail(repository);
            var result = usecase.Handle("inexistent@email.com.br");

            Assert.IsTrue(result.IsLeft);
            Assert.IsTrue(result.LeftOrDefault() is EmailNotFoundError);
        }
    }
}
