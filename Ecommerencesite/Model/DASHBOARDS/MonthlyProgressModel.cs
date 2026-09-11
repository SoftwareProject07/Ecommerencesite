using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class MonthlyProgressModel
          {
                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }         
                    public string Month { get; set; }
                    public string MetricName { get; set; }
                    public double Score { get; set; }
          }
}
