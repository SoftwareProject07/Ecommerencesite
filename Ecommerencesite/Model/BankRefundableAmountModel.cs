using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerencesite.Model
{
          public class BankRefundableAmountModel
          {
                    [Key]
                    public int BankRefundableAmountid { get; set; }

                    public string? Bank_CustomerName { get; set; }//customer name 


                 //   [Column(TypeName = "decimal(18,2)]")]
                    public decimal? BankRefundableAmount { get; set; }

                    public bool? BankRefundableAmountStatus { get; set; }

                    // --- Bank Account Related Validations ---

                    [Required(ErrorMessage = "Bank name is required")]
                    [StringLength(100)]
                    public string? BankName { get; set; }

                    [Required(ErrorMessage = "Account number is required")]
                    [RegularExpression(@"^\d{9,18}$", ErrorMessage = "Invalid Bank Account Number")]
                    public string? BankAccountNumber { get; set; }

                    [Required(ErrorMessage = "Please confirm your account number")]
                    [Compare("BankAccountNumber", ErrorMessage = "Account numbers do not match")]
                    [NotMapped] // Agar database mein save nahi karna hai tab
                    public string? ConfirmBankAccountNumber { get; set; }



                    [Required(ErrorMessage = "IFSC code is required")]
                    [RegularExpression(@"^[A-Z]{4}0[A-Z0-9]{6}$", ErrorMessage = "Invalid IFSC Code format")]
                    public string? BankIFSCCode { get; set; }

                    public string? BankBranchName { get; set; }
                    public string? BankBranchAddress { get; set; }
                    public string? BankBranchCity { get; set; }
                    public string? BankBranchState { get; set; }

                    public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
          }
}