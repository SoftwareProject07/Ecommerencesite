using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
       //   [Table("CandidateApplications")]
          public class CandidateApplicationModule
          {
                    [Key]
                    public int Id { get; set; }

                    public int JobId { get; set; } // Kis Job ke liye apply kiya (Foreign Key)

                    [Required(ErrorMessage = "Full Name is required")]
                    [StringLength(100)]
                    public string FullName { get; set; } // Candidate ka naam

                    [Required(ErrorMessage = "Email is required")]
                    [EmailAddress(ErrorMessage = "Invalid Email Address")]
                    [StringLength(150)]
                    public string Email { get; set; } // Email address

                    [Required(ErrorMessage = "Phone number is required")]
                    [Phone(ErrorMessage = "Invalid Phone Number")]
                    [StringLength(15)]
                    public string PhoneNo { get; set; } // Contact number

                    [Required(ErrorMessage = "Resume is required")]
                    public string ResumeUrl { get; set; } // Uploaded Resume file link/path

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal CurrentCTC { get; set; } // Abhi ki salary

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal ExpectedCTC { get; set; } // Expected salary

                    [StringLength(50)]
                    public string NoticePeriod { get; set; } // Jaise: Immediate, 15 Days

                    [StringLength(50)]
                    public string Status { get; set; } = "Applied"; // Status: Applied, Shortlisted, Interview, Selected, Rejected

                    public DateTime AppliedDate { get; set; } = DateTime.Now; // Kab apply kiya
          }
}