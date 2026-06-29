

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerencesite.Model
{
          public class LivenessCheckRequestModel
          {
                    [Key]
                    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

                    public int SessionId { get; set; }
                    // Base64 encoded image or feature vectors
                    public string FrameData { get; set; } = string.Empty;
                    public int BlinkCount { get; set; }
                    public string ImagePath { get; set; } = string.Empty;

                    public DateTime CreatedDate { get; set; } = DateTime.Now;
          }

          public class LivenessResponse
          {

                    public bool IsLive { get; set; }
                    public string Message { get; set; }
                    public double ConfidenceScore { get; set; }
          }




}
