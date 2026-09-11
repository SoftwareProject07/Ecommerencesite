using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class WeightProgressData
          {
                    [Key]
                    public int Id { get; set; }   
                    public int UserId { get; set; }         
                    public string Date { get; set; }
                    public double Weight { get; set; }
          }
}
