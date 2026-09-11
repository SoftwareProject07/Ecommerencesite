using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class Medication
          {
                    [Key]
                    public int Id { get; set; }

                    [Required]
                    [MaxLength(100)]
                    public string MedicationName { get; set; }

                    [Required]
                    [MaxLength(50)]
                    public string Dosage { get; set; } // e.g., 500mg, 1 tablet

                    [Required]
                    [MaxLength(50)]
                    public string Frequency { get; set; } // e.g., Twice a day

                    [Required]
                    public DateTime StartDate { get; set; }

                    [Required]
                    public DateTime EndDate { get; set; }

                    public string Status { get; set; } = "Active"; // Active, Completed, Discontinued
          }
}
