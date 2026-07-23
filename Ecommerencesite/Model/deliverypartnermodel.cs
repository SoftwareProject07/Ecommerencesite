using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          //Address
          public class deliverypartnermodel
          {
                    [Key]
                    public int Id { get; set; }
                    public string UserId { get; set; }
                    public string AddressLine { get; set; }
                    public string City { get; set; }
                    public string Pincode { get; set; }

                    [Column(TypeName = "decimal(18,6)")] // Map coordinates ke liye precision zaroori hai
                    public decimal Latitude { get; set; }   // Map coordinate

                    [Column(TypeName = "decimal(18,6)")]
                    public decimal Longitude { get; set; }  // Map coordinate
          }
}
