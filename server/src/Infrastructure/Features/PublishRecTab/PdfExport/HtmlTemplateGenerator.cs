using System.Text;
using Application.DTO.PublishRecTab;

namespace Infrastructure.Features.PublishRecTab.PdfExport
{
    public static class HtmlTemplateGenerator
    {
        private static string GetTabsBody(ICollection<PublishRecTabDeployDto> recTabs)
        {
            if (recTabs.Count == 0) return "<div style='text-align:center;font-size:25px;padding:18px;'>Нет рекомендованых к зачислению</div>";

            var sb = new StringBuilder();

            sb.Append(@"
                <table align='center'>
                    <tr>
                        <th>Идентифик<br/>ационный<br/>номер</th>
                        <th>СНИЛС</th>
                        <th>ВИ</th>
                        <th>Сумма баллов</th>
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
                    </tr>",
                    rec.UserId, rec.Snils, rec.TestType, rec.SumPoints, rec.IndividPoint > 0 ? rec.IndividPoint : "-", rec.SostType, rec.Sogl, rec.Advantage);
            }

            sb.Append("</table>");

            return sb.ToString();
        }
        public static string GetHTMLString(ICollection<PublishRecTabDeployDto> recTabs, string title)
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
                            padding: 15px;
                            text-align: center;
                        }

                        table,
                        th,
                        td {
                        border: 1px solid;
                        border-collapse: collapse;
                        }
                    </style>
                    </head>
                    <body>");

            sb.Append($"<h1>Список рекомендованных к зачислению<br/>{title}</h1>");


            sb.Append(GetTabsBody(recTabs));

            sb.Append(@"
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}