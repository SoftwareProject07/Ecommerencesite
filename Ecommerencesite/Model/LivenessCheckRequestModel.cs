

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerencesite.Model
{
          public class LivenessCheckRequestModel
          {
                    [Key]

                    public int SessionId { get; set; }
                    // Base64 encoded image or feature vectors
                    public string FrameData { get; set; }
                    public int BlinkCount { get; set; }
          }

          public class LivenessResponse
          {

                    public bool IsLive { get; set; }
                    public string Message { get; set; }
                    public double ConfidenceScore { get; set; }
          }
}
