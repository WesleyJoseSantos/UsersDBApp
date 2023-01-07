using System;
using System.Windows.Forms;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.Usecases.Users;

namespace UsersDBApp
{
    public partial class CreateUserForm : Form
    {
        public ICreateUser CreateUser { get; set; }

        public CreateUserForm(ICreateUser createUser)
        {
            CreateUser = createUser;
            InitializeComponent();
        }

        private void UserRegistration_Load(object sender, EventArgs e)
        {
            comboBoxLevel.SelectedIndex = 0;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var user = new UserDTO(
                textBoxName.Text,
                textBoxEmail.Text,
                textBoxPhone.Text,
                textBoxPass.Text,
                (UserLevel)comboBoxLevel.SelectedIndex
            );

            var result = CreateUser.Handle(user);

            if(result.IsLeft)
            {
                MessageBox.Show(result.LeftOrDefault().Message, result.LeftOrDefault().Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(new NoError().Message, new NoError().Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxName.Text = "";
                textBoxEmail.Text = "";
                textBoxPhone.Text = "";
                textBoxPass.Text = "";
                comboBoxLevel.SelectedIndex = 0;
            }
        }
    }
}
