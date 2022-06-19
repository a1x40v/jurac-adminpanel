using System.Text;
using Application.DTO.PublishRecTab;

namespace Infrastructure.Features.PublishRecTab.PdfExport
{
    public static class HtmlTemplateGenerator
    {
        public static string GetHTMLString(ICollection<PublishRecTabExportDto> recTabs)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <!DOCTYPE html>
                        <html>
                            <head>
                            <style>
                                body {
                                    padding-top: 10px;
                                }

                                td, th {
                                    padding: 10px;
                                    text-align: center;
                                }
                            </style>
                            </head>
                            <body>
                                <h1>
                                    Список рекомендованных к зачислению<br/>
                                    Бакалавриат ОФО Гражданско-правовой профиль
                                </h1>
                                <table align='center'>
                                    <tr>
                                        <th>Идентифик<br/>ационный<br/>номер</th>
                                        <th>СНИЛС</th>
                                        <th>ВИ</th>
                                        <th>Сумма баллов</th>
                                        <th>Обществоз<br/>нание</th>
                                        <th>Русский<br/>язык</th>
                                        <th>Предмет<br/>по выбору:<br/>ТГП/ОКП</th>
                                        <th>Инд. достижения</th>
                                        <th>Состояние</th>
                                        <th>Согласие на<br/>зачисление</th>
                                        <th>Приемущественное<br/>право</th>
                                    </tr>");

            foreach (var rec in recTabs)
            {
                sb.AppendFormat(@"
                    <tr>
                        <td>{0}</td>
                        <td>{1}</td>
                        <td>{2}</td>
                        <td>{3}</td>
                        <td>{4}</td>
                        <td>{5}</td>
                        <td>{6}</td>
                        <td>{7}</td>
                        <td>{8}</td>
                        <td>{9}</td>
                        <td>{10}</td>
                    </tr>",
                    rec.UserId, rec.Snils, rec.TestType, rec.SumPoints, rec.ObshPoint, rec.RusPoint,
                    rec.ChosenPoint, rec.IndividPoint > 0 ? rec.IndividPoint : "-", rec.SostType, rec.Sogl, rec.Advantage);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}