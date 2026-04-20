using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class QRCashCodeModels
          {
                    [Key]
                    public int QRcashcodeid { get; set; }
                    public string? BankName { get; set; }
                    public string? CustomerName { get; set; }
                    public double  itemprice { get; set; }
                    public  double totalitem { get; set; }
                    public double totalquantity { get; set; }
                    public double TOTALAMOUNT { get; set; }


                    public double QRcashcode { get; set; }
          }
}
