using System.Globalization;
using Application.Contracts.Infrastructure;
using Application.DTO.User;
using ClosedXML.Excel;

namespace Infrastructure.Features.Users
{
    public class UserExporter : IUserExporter
    {
        public MemoryStream ExportUsers(ICollection<ExportedUserDto> users)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Абитуриенты");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "№";
                worksheet.Cell(currentRow, 2).Value = "Фамилия";
                worksheet.Cell(currentRow, 3).Value = "Имя";
                worksheet.Cell(currentRow, 4).Value = "Отчество";
                worksheet.Cell(currentRow, 5).Value = "Дата рождения";
                worksheet.Cell(currentRow, 6).Value = "Образовательная организация";
                worksheet.Cell(currentRow, 7).Value = "Адрес регистрации";
                worksheet.Cell(currentRow, 8).Value = "СНИЛС";

                foreach (var user in users)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = currentRow - 1;
                    worksheet.Cell(currentRow, 2).Value = user.LastName;
                    worksheet.Cell(currentRow, 3).Value = user.FirstName;
                    worksheet.Cell(currentRow, 4).Value = user.Patronymic;
                    worksheet.Cell(currentRow, 5).Value = user.DateOfBirth.ToShortDateString();
                    worksheet.Cell(currentRow, 6).Value = user.NameUz;
                    worksheet.Cell(currentRow, 7).Value = user.Address;
                    worksheet.Cell(currentRow, 8).Value = user.Snils;
                }

                worksheet.Columns().AdjustToContents();  // Adjust column width
                worksheet.Rows().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream;
                }
            }
        }
    }
}