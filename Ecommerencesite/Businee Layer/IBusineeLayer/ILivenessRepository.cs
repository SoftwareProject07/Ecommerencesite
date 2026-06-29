
using Ecommerencesite.Model;
using Ecommerencesite.ViewModel;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
    public interface ILivenessRepository
    {
                    Task<LivenessResponse> VerifyBlinkAsync(LivenessCheckRequestModel request);
                    public List<LivenessViewModel> GetLivenessAsync();



                    Task<LivenessCheckRequestModel> GetBySessionIdAsync(long sessionId);

                 //   Task<LivenessResponse> VerifyBlinkAsync(LivenessCheckRequestModel request);
          }
}
