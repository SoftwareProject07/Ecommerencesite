using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.HAPPYCLIENT
{
          public class HappyClient
          {
                    [Key]
                    public int Id { get; set; }

                    [Required]
                    [MaxLength(100)]
                    public string ClientName { get; set; } = string.Empty;

                    [MaxLength(100)]
                    public string Designation { get; set; } = string.Empty;

                    [MaxLength(150)]
                    public string Company { get; set; } = string.Empty;

                    [Required]
                    [MaxLength(1000)]
                    public string TestimonialText { get; set; } = string.Empty;

                    [Range(1, 5)]
                    public int Rating { get; set; } = 5;

                    [MaxLength(500)]
                    public string ImageUrl { get; set; } = string.Empty;

                    public bool IsActive { get; set; } = true;

                    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
          }
}
