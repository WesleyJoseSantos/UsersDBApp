using System;
using System.Windows.Forms;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Modules.Users;
using UsersDBApi.Domain.repositories;
using UsersDBApi.Domain.Usecases.Users;
using UsersDBApi.Infra.Modules.Users;
using UsersDBApi.Infra.Repositories;
using UsersDBApi.Infra.Usecases.Users;

namespace UsersDBApp
{
    internal static class Program
    {
        private static readonly IUsersRepository repository = new UsersRepository();

        private static readonly ICreateUser createUser = new CreateUser(repository);
        private static readonly IGetAllUsers getAllUsers = new GetAllUsers(repository);
        private static readonly IGenerateReport generateReport = new GenerateReport(getAllUsers);
        private static readonly IGetUserByEmail getUserByEmail = new GetUserByEmail(repository);
        private static readonly IGetUserById getUserById = new GetUserById(repository);
        private static readonly IGetUsersByName getUsersByName = new GetUserByName(repository);
        private static readonly ISignIn signIn = new SignIn(getUserByEmail);

        private static readonly IUsersModule usersModule = new UsersModule(createUser, generateReport, getAllUsers, getUserByEmail, getUserById, getUsersByName, signIn);

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if(Properties.Settings.Default.email != "")
            {
                var credentials = new UserCredentialsDTO(
                    Properties.Settings.Default.email,
                    Properties.Settings.Default.password);
                var result = signIn.Handle(credentials);
                if(result.IsRight)
                {
                    var home = new Home(result.RightOrDefault(), usersModule);
                    home.FormClosed += Exit;
                    home.Show();

                    Application.Run();
                    return;
                }
            }

            var signInDialog = new SignInDialog(usersModule);
            signInDialog.FormClosed += Exit;
            signInDialog.Show();
            Application.Run();
        }

        public static void Exit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
