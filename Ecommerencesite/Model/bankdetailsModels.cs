using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model
{
          public class bankdetailsModles
          {
                    [Key]
                    public int BankId { get; set; }
                    public string? BankName { get; set; }
                    public string? CardNumber { get; set; } 
                    public string? ExpiryDate { get; set; }// MM/YY format
                    public string? CVV { get; set; }// 3 or 4 digit security code
                              public string? CardholderName { get; set; }
          }
}
