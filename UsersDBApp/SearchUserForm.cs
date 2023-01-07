using System.Windows.Forms;
using UsersDBApi.Domain.Modules.Users;
using UsersDBApi.Domain.Usecases.Users;

namespace UsersDBApp
{
    public partial class SearchUserForm : Form
    {
        IUsersModule usersModule;

        public SearchUserForm(IUsersModule usersModule)
        {
            InitializeComponent();
            this.usersModule = usersModule;
        }

        private void buttonSearch_Click(object sender, System.EventArgs e)
        {
            var name = textBoxName.Text;
            var result = textBoxName.Text == "*" ? usersModule.GetAll.Handle() : usersModule.GetByName.Handle(name);

            if (result.IsLeft)
            {
                MessageBox.Show(result.LeftOrDefault().Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var users = result.RightOrDefault();

                listViewUsers.Items.Clear();

                foreach (var user in users)
                {
                    var listIt = new ListViewItem();
                    listIt.Text = user.Id.ToString();
                    listIt.SubItems.Add(user.Name);
                    listIt.SubItems.Add(user.Email);
                    listIt.SubItems.Add(user.Phone);
                    listIt.SubItems.Add(user.Level.ToString());
                    listIt.SubItems.Add(user.CreatedAt);

                    listViewUsers.Items.Add(listIt);
                }
            }
        }
    }
}
