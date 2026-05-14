
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
    public interface ILivenessRepository
    {
                    Task<LivenessResponse> VerifyBlinkAsync(LivenessCheckRequestModel request);
          }
}
