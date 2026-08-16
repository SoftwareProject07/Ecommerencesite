using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
          public class CustomerAccountantAccount
          {
                    [Key]
                    public int Id { get; set; }

                    //   [Required, MaxLength(100)]
                    public string? CustomerName { get; set; } = null;

                    //[Required, MaxLength(100)]
                    //[EmailAddress]
                    public string? Email { get; set; } = null;

                   // [Required, MaxLength(20)]
                    public string? Phone { get; set; } =null;

                    //  [Column(TypeName = "decimal(18,2)]")]
                    public decimal? OpeningBalance { get; set; } 

                  //  [Column(TypeName = "decimal(18,2)]")]
                    public decimal? CurrentBalance { get; set; }

                    //  [Required, MaxLength(50)]
                    public string? AccountType { get; set; } = null; // Receivable / Payable

                    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

                   // [MaxLength(200)]
                    public string? CreatedByAccountant { get; set; } = null;
          }
}
