using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.LABTESTMODEL
{
          public class BookingResponseModel
          {
                    [Key]
                    public int BookingId { get; set; }
                    public string Status { get; set; }
                    public decimal FinalAmount { get; set; }
                    public string ExecutiveName { get; set; }
                    public string ExecutiveMobile { get; set; }
                    public string TrackingStep { get; set; }
          }
}
