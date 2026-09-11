using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.DASHBOARDS
{
          public class AvailableTestModel
          {
                    [Key]
                    public int Id { get; set; }
                    public string TestName { get; set; }
                    public string Description { get; set; }
                    public decimal Price { get; set; }
                    public string Category { get; set; } // e.g., "Blood Test", "Ultrasound", "General"
          }
}
