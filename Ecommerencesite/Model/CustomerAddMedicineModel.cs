using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class CustomerAddMedicineModel
          {
                    [Key]
                    public int CustomerAddMedicineModelId { get; set; }
                    public string? CustomerName { get; set; } = null;
                    public string? MedicineName { get; set; } = null;
                    public string? MedicineDescription { get; set; } = null;

          }
}
