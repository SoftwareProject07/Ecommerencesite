using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class HealthHistoryModel
          {

                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }
                    public string Condition { get; set; }
                    public string DiagnosedDate { get; set; }
                    public string DoctorNotes { get; set; }
          }
}
