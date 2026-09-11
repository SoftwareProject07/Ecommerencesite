using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class PrescriptionModel
          {
                    [Key]
                    public int Id { get; set; }
                    public int UserId { get; set; }         
                    public string DoctorName { get; set; }
                    public string DateIssued { get; set; }
                    public string PrescriptionUrl { get; set; }
          }
}
