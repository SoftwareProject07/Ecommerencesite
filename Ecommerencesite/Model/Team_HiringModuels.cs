using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerencesite.Model
{
         // [Table("Team_HiringModules")]
          public class Team_HiringModules
          {
                    [Key]
                    public int Id { get; set; }

                    [Required(ErrorMessage = "Job Title is required")]
                    [StringLength(150)]
                    public string JobTitle { get; set; } // Jaise: Software Engineer

                    [Required(ErrorMessage = "Job Description is required")]
                    public string JobDescription { get; set; } // Roles & Responsibilities

                    [Required(ErrorMessage = "Department is required")]
                    [StringLength(100)]
                    public string Department { get; set; } // Jaise: IT, Sales

                    [StringLength(50)]
                    public string ExperienceRequired { get; set; } // Jaise: 2-4 Years

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal OfferedCTC { get; set; } // Salary package

                    [StringLength(100)]
                    public string Location { get; set; } // Job Location / Remote

                    public int NoOfOpenings { get; set; } // Kitni vacancies hain

                    public bool IsActive { get; set; } = true; // Job open hai ya close

                    public DateTime PostedDate { get; set; } = DateTime.Now;

                    public DateTime ClosingDate { get; set; } // Application last date
          }
}