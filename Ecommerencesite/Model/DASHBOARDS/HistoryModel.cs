using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class HistoryModel
          {

                    [Key]
                    public int Id { get; set; }

                    [Required]
                    public string ActionType { get; set; } // e.g., "PRESCRIPTION_VIEW", "MEDICINE_ORDER"

                    public string Description { get; set; } // Detailed message

                    public string IpAddress { get; set; }
          }


}