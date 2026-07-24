using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class DoctorAssigntoPatientMOdel
          {
                    [Key]
                    public int DoctorAssigntoPatientod { get; set; }
                    public string? DoctorName { get; set; } 

                    public string? DoctorType { get; set; }
          }
}
