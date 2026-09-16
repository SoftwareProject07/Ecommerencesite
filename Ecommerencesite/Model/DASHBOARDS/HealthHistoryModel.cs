using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class HealthHistoryModel
          {

                    //[Key]
                    //public int Id { get; set; }
                    //public int UserId { get; set; }
                    //public string Condition { get; set; }
                    //public string DiagnosedDate { get; set; }
                    //public string DoctorNotes { get; set; }





                    [Key]
                    public int Id { get; set; }

                    //[Required]
                    //public int UserId { get; set; }

                    [Required]
                    [StringLength(100)]
                    public string ConditionName { get; set; } // e.g., Hypertension, Type 2 Diabetes

                    public DateTime DiagnosisDate { get; set; }

                    [StringLength(500)]
                    public string Description { get; set; }

                    [StringLength(200)]
                    public string TreatingDoctor { get; set; }

                    [StringLength(50)]
                    public string Status { get; set; } // Active, Resolved, Managed

                    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
          }
}
