using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class MedicationTrackerModel
          {
                    [Key]
                    public int Id { get; set; }
                    public string MedicationName { get; set; }
                    public string Dosage { get; set; }
                    public string Frequency { get; set; }
                    public DateTime? StartDate { get; set; }
                    public DateTime? EndDate { get; set; }
                    public string Status { get; set; }
          }
}
