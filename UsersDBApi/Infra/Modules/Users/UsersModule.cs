using UsersDBApi.Domain.Modules.Users;
using UsersDBApi.Domain.Usecases.Users;

namespace UsersDBApi.Infra.Modules.Users
{
    public class UsersModule : IUsersModule
    {
        private readonly ICreateUser create;
        private readonly IGenerateReport generateReport;
        private readonly IGetAllUsers getAll;
        private readonly IGetUserByEmail getByEmail;
        private readonly IGetUserById getById;
        private readonly IGetUsersByName getByName;
        private readonly ISignIn signIn;

        public ICreateUser Create => create;
        public IGenerateReport GenerateReport => generateReport;
        public IGetAllUsers GetAll => getAll;
        public IGetUserByEmail GetByEmail => getByEmail;
        public IGetUserById GetById => getById;
        public IGetUsersByName GetByName => getByName;
        public ISignIn SignIn => signIn;

        public UsersModule(ICreateUser create, IGenerateReport generateReport, IGetAllUsers getAll, IGetUserByEmail getByEmail, IGetUserById getById, IGetUsersByName getByName, ISignIn signIn)
        {
            this.create = create;
            this.generateReport = generateReport;
            this.getAll = getAll;
            this.getByEmail = getByEmail;
            this.getById = getById;
            this.getByName = getByName;
            this.signIn = signIn;
        }
    }
}
