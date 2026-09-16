
using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class MonthlyProgressModel
          {
                    //[Key]
                    //public int Id { get; set; }
                    //public int UserId { get; set; }         
                    //public string Month { get; set; }
                    //public string MetricName { get; set; }
                    //public double Score { get; set; }


                    [Key]

                    public int Id { get; set; }
                    [Required]
                    public string? MonthYear { get; set; } = null; // Example: "June 2026"
                    public decimal Weight { get; set; }    // Example: 175.5
                    public int AvgGlucose { get; set; }    // Example: 110
                    public string? BloodPressureStatus { get; set; } = null; // Example: "Normal"
                    public string? Notes { get; set; } = null;      // Example: "Good improvement in diet"
                    public DateTime RecordedDate { get; set; } = DateTime.UtcNow;
          }
}
