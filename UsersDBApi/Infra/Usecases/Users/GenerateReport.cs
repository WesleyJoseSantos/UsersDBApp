using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using UsersDBApi.Domain.DTOs;
using UsersDBApi.Domain.Errors;
using UsersDBApi.Domain.Usecases.Users;

namespace UsersDBApi.Infra.Usecases.Users
{
    public class GenerateReport : IGenerateReport
    {
        private readonly IGetAllUsers getAllUsers;

        public GenerateReport(IGetAllUsers getAllUsers)
        {
            this.getAllUsers = getAllUsers;
        }

        public IBaseError Handle(UserDTO user, Document document, string path, string titleText)
        {
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            document.Open();

            Paragraph title = new Paragraph();
            title.Font = new Font(Font.FontFamily.TIMES_ROMAN, 35);
            title.Alignment = Element.ALIGN_CENTER;
            title.Add($"{titleText}\n\n\n");
            document.Add(title);

            Paragraph header = new Paragraph();
            header.Font = new Font(Font.FontFamily.TIMES_ROMAN, 12);
            header.Alignment = Element.ALIGN_LEFT;
            header.Add($"Usuário: {user.Name}\n");
            header.Add($"Email: {user.Email}\n");
            header.Add($"Data de Emissão: {DateTime.Now}\n\n");
            document.Add(header);

            Paragraph tableDescription = new Paragraph();
            tableDescription.Font = new Font(Font.FontFamily.TIMES_ROMAN, 10);
            tableDescription.Alignment = Element.ALIGN_LEFT;
            tableDescription.Add("Tabela de Usuários:\n\n");
            document.Add(tableDescription);

            var result = getAllUsers.Handle();

            Font fontH1 = new Font(Font.FontFamily.TIMES_ROMAN, 9, Font.NORMAL);
            PdfPTable table = new PdfPTable(6);

            table.AddCell(new PdfPCell(new Phrase("Id", fontH1)));
            table.AddCell(new PdfPCell(new Phrase("Nome", fontH1)));
            table.AddCell(new PdfPCell(new Phrase("Email", fontH1)));
            table.AddCell(new PdfPCell(new Phrase("Telefone", fontH1)));
            table.AddCell(new PdfPCell(new Phrase("Privilégios", fontH1)));
            table.AddCell(new PdfPCell(new Phrase("Data Criação", fontH1)));


            table.SetWidths(new int[] { 25, 150, 150, 80, 75, 75});

            if(result.IsRight)
            {
                var users = result.RightOrDefault();
                foreach (var it in users)
                {
                    table.AddCell(new PdfPCell(new Phrase(it.Id.ToString(), fontH1)));
                    table.AddCell(new PdfPCell(new Phrase(it.Name, fontH1)));
                    table.AddCell(new PdfPCell(new Phrase(it.Email, fontH1)));
                    table.AddCell(new PdfPCell(new Phrase(it.Phone, fontH1)));
                    table.AddCell(new PdfPCell(new Phrase(it.Level.ToString(), fontH1)));
                    table.AddCell(new PdfPCell(new Phrase(it.CreatedAt, fontH1)));
                }
                document.Add(table);
                document.Close();
            }
            else
            {
                return result.LeftOrDefault();
            }
            
            return new NoError();
        }

    }
}
