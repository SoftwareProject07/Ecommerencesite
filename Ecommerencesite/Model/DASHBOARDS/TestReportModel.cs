using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class TestReportModel
          {
                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }         
                    public string TestName { get; set; }
                    public string Date { get; set; }
                    public string ResultSummary { get; set; }
                    public string ReportFileUrl { get; set; }
          }
}
