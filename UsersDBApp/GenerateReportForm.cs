using iTextSharp.text;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.Usecases.Users;

namespace UsersDBApp
{
    public partial class GenerateReportForm : Form
    {
        private readonly UserDTO user;
        private readonly IGenerateReport generateReport;
        private readonly string initialDir;
        private Rectangle pageSize;

        public GenerateReportForm(UserDTO user, IGenerateReport generateReport)
        {
            InitializeComponent();
            this.user = user;
            this.generateReport = generateReport;
            initialDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void GenerateReportForm_Load(object sender, EventArgs e)
        {
            comboBoxFormat.SelectedIndex = 4;
            checkBoxOpen.Checked = true;
            textBoxPath.Text = $"{initialDir}\\relatorio.pdf";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = textBoxPath.Text,
                Filter = "Arquivo PDF | *.pdf"
            };

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = saveFileDialog.FileName;
            }
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            var doc = new Document(pageSize);
            doc.SetMargins(40, 40, 40, 80);

            var result = generateReport.Handle(user, doc, textBoxPath.Text, textBoxTitle.Text);

            if(checkBoxOpen.Checked && result is NoError)
            {
                Process.Start(textBoxPath.Text);
            }
            else
            {
                MessageBox.Show(result.Message, result.Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFormat.SelectedIndex)
            {
                case 0:
                    pageSize = PageSize.A0;
                    break;
                case 1:
                    pageSize = PageSize.A1;
                    break;
                case 2: 
                    pageSize = PageSize.A2;
                    break; 
                case 3:
                    pageSize = PageSize.A3;
                    break; 
               case 4:
                    pageSize = PageSize.A4;
                    break;
                case 5:
                    pageSize = PageSize.A5;
                    break;
                default:
                    pageSize = PageSize.A4;
                    break;
            }
        }
    }
}
