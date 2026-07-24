using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class PatientDetailsModel
          {
                    [Key]
                    public int patientDetailsId { get; set; }
                    public string? PatientName { get; set; }
                    public int age { get; set; }
                    public string? PatientReason { get; set; } 
                  //  public string? DoctorAssignto { get; set; } = null;
          }
}
