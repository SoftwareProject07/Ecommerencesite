using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class MedicineChat
          {
                    [Key]
                    public int Id { get; set; }

                    public string CustomerName { get; set; }

                    public string Question { get; set; }

                    public string Answer { get; set; }

                    public DateTime CreatedDate { get; set; }
          }
}
