using System;
using System.Drawing;
using System.Windows.Forms;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.Modules.Users;

namespace UsersDBApp
{
    public partial class Home : Form
    {
        private readonly UserDTO user;
        private readonly IUsersModule usersModule;

        private readonly CreateUserForm createUserForm;
        private readonly SearchUserForm searchUserForm;
        private readonly GenerateReportForm generateReportForm;
        
        public Home(UserDTO user, IUsersModule usersModule)
        {
            InitializeComponent();

            this.user = user;
            this.usersModule = usersModule;

            createUserForm = new CreateUserForm(usersModule.Create);
            searchUserForm = new SearchUserForm(usersModule);
            generateReportForm = new GenerateReportForm(user, usersModule.GenerateReport);

            createUserForm.TopLevel = false;
            searchUserForm.TopLevel = false;
            generateReportForm.TopLevel = false;

            Controls.Add(createUserForm);
            Controls.Add(searchUserForm);
            Controls.Add(generateReportForm);

            createUserForm.Dock = DockStyle.Fill;
            searchUserForm.Dock = DockStyle.Fill;
            generateReportForm.Dock = DockStyle.Fill;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            labelEmail.Text = user.Email;
        }

        private void buttonMenu_MouseEnter(object sender, EventArgs e)
        {
            var it = (Control)sender;
            var parent = it.Parent;
            parent.BackColor = Color.LightGray;
        }

        private void buttonMenu_MouseLeave(object sender, EventArgs e)
        {
            var it = (Control)sender;
            var parent = it.Parent;
            parent.BackColor = menu.BackColor;
        }

        private void buttonRegister_MouseClick(object sender, MouseEventArgs e)
        {
            if(user.Level == UserLevel.Administrator)
            {
                createUserForm.Show();
                createUserForm.BringToFront();
            }
            else
            {
                MessageBox.Show(new InsuficientPrivileges().Message, new InsuficientPrivileges().Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if(user.Level != UserLevel.None)
            {
                searchUserForm.Show();
                searchUserForm.BringToFront();
            }
            else
            {
                MessageBox.Show(new InsuficientPrivileges().Message, new InsuficientPrivileges().Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (user.Level != UserLevel.None)
            {
                generateReportForm.Show();
                generateReportForm.BringToFront();
            }
            else
            {
                MessageBox.Show(new InsuficientPrivileges().Message, new InsuficientPrivileges().Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLogOff_MouseClick(object sender, MouseEventArgs e)
        {
            var signInDialog = new SignInDialog(usersModule);
            signInDialog.FormClosed += Program.Exit;
            signInDialog.Show();

            Properties.Settings.Default.email = "";
            Properties.Settings.Default.password = "";
            Properties.Settings.Default.Save();

            FormClosed -= Program.Exit;
            Close();
        }

        private void buttomExit_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
