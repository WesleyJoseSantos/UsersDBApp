using System;
using System.Windows.Forms;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Modules.Users;

namespace UsersDBApp
{
    public partial class SignInDialog : Form
    {
        private IUsersModule usersModule;

        public SignInDialog(IUsersModule usersModule)
        {
            this.usersModule = usersModule;
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var credentials = new UserCredentialsDTO(
                textBoxEmail.Text,
                textBoxPass.Text
            );

            var result = usersModule.SignIn.Handle(credentials);

            if(result.IsLeft)
            {
                MessageBox.Show(result.LeftOrDefault().Message, result.LeftOrDefault().Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                var user = result.RightOrDefault();
                var home = new Home(user, usersModule);
                home.FormClosed += Program.Exit;
                home.Show();

                Properties.Settings.Default.email= user.Email;
                Properties.Settings.Default.password= user.Password;
                Properties.Settings.Default.Save();

                FormClosed -= Program.Exit;
                Close();
            }
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPass.UseSystemPasswordChar = !checkBoxShowPass.Checked;
        }
    }
}
