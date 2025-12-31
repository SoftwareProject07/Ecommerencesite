namespace Ecommerencesite.MODELDTO
{
          public class MedicineDto
          {
                    public int id { get; set; }
                    //   public string? Name { get; set; }

                    public string? ExpiryDate { get; set; } = null;// 👈 string=null;
          }
}
