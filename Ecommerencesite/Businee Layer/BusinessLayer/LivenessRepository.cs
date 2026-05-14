using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database; // Ensure this points to your DbContext namespace
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using System.Threading.Tasks;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class LivenessRepository : ILivenessRepository
          {
                    // 1. Inject the Database Context, NOT the Repository itself
                    private readonly Ecommerecewebstedatabase _db;

                    public LivenessRepository(Ecommerecewebstedatabase db)
                    {
                              _db = db;
                    }

                    public async Task<LivenessResponse> VerifyBlinkAsync(LivenessCheckRequestModel request)
                    {
                              // 1. Process Logic: Check if at least one blink occurred
                              bool isVerified = request != null && request.BlinkCount >= 1;

                              var response = new LivenessResponse
                              {
                                        IsLive = isVerified,
                                        ConfidenceScore = isVerified ? 0.98 : 0.05,
                                        Message = isVerified ? "Liveness verified successfully." : "Blink not detected."
                              };

                              // 2. Save the attempt to the Database
                              if (request != null)
                              {
                                        _db.livenessrequestcheckmodel.Add(request);
                                        await _db.SaveChangesAsync();
                              }

                              return response;
                    }
          }
}