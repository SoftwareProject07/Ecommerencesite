using System;
using System.ComponentModel.DataAnnotations;

namespace LabTestApp.Models
{
          public class OfferTestModel
          {
                    [Key]
                    public int Id { get; set; }

                    [Required]
                    public string TestName { get; set; }

                    public string Description { get; set; }

                    public decimal OriginalPrice { get; set; }

                    public decimal OfferPrice { get; set; }

                    public int DiscountPercentage { get; set; } // e.g., 20, 50 etc.

                    public string ImageUrl { get; set; } // Admin ke create kiye gaye test ki image ke liye

                    public DateTime StartDate { get; set; }

                    public DateTime EndDate { get; set; }

                    public bool IsActive { get; set; }
          }
}