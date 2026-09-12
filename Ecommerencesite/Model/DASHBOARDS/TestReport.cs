using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class TestReport
          {
                    [Key]
                    public int Id { get; set; }
                    public string TestName { get; set; }
                    public string Date { get; set; }
                    public string Status { get; set; }
                    public string ResultSummary { get; set; }
          }
}
