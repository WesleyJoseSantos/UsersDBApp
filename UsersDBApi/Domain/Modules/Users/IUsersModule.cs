using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDBApi.Domain.Usecases.Users;
using UsersDBApi.Infra.Usecases;

namespace UsersDBApi.Domain.Modules.Users
{
    public interface IUsersModule
    {
        ICreateUser Create { get; }
        IGenerateReport GenerateReport { get; }
        IGetAllUsers GetAll { get; }
        IGetUserByEmail GetByEmail { get; }
        IGetUserById GetById { get; }
        IGetUsersByName GetByName { get; }
        ISignIn SignIn { get; }
    }
}
