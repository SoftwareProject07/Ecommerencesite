using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class AssignRaiseTicketModel
          {
                    [Key]
                    public int AssignId { get; set; }
                    //public string AssignedTo { get; set; }
                    //public string MobileNumber { get; set; }
                    public string? AssignedTo { get; set; } = null;
          }
}
