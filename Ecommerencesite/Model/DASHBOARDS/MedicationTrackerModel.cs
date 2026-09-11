using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class MedicationTrackerModel
          {
                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }         
                    public string MedicineName { get; set; }
                    public string Dosage { get; set; }
                    public string Timing { get; set; }
                    public bool IsTaken { get; set; }
          }
}
