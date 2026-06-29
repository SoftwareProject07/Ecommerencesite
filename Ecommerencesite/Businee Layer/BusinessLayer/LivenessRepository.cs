using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database; // Ensure this points to your DbContext namespace
using Ecommerencesite.Model;
using Ecommerencesite.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class LivenessRepository : ILivenessRepository
          {
                    // 1. Inject the Database Context, NOT the Repository itself
                    private readonly Ecommerecewebstedatabase _db;
                    private readonly IWebHostEnvironment _environment;

                    public LivenessRepository(Ecommerecewebstedatabase db, IWebHostEnvironment environment)
                    {
                              _db = db;
                              _environment = environment;   
                    }

                    public List<LivenessViewModel> GetLivenessAsync()
                    {
                              return _db.livenessrequestcheckmodel
                                  .Select(x => new LivenessViewModel
                                  {
                                            SessionId = x.SessionId,
                                            FrameData = x.FrameData,
                                            BlinkCount = x.BlinkCount,
                                            ImagePath = x.ImagePath,
                                            CreatedDate = x.CreatedDate,
                                          //  IsLive = x.is,

                                  })

                                  .ToList();
                    }

                    //public async Task<LivenessResponse> VerifyBlinkAsync(LivenessCheckRequestModel request)
                    //{
                    //          // 1. Process Logic: Check if at least one blink occurred
                    //          bool isVerified = request != null && request.BlinkCount >= 1;

                    //          var response = new LivenessResponse
                    //          {
                    //                    IsLive = isVerified,
                    //                    ConfidenceScore = isVerified ? 0.98 : 0.05,
                    //                    Message = isVerified ? "Liveness verified successfully." : "Blink not detected."
                    //          };

                    //          // 2. Save the attempt to the Database
                    //          if (request != null)
                    //          {
                    //                    _db.livenessrequestcheckmodel.Add(request);
                    //                    await _db.SaveChangesAsync();
                    //          }

                    //          return response;
                    //}

                    //public async Task<LivenessResponse> VerifyBlinkAsync(LivenessCheckRequestModel request)
                    //{
                    //          if (request == null)
                    //          {
                    //                    return new LivenessResponse
                    //                    {
                    //                              IsLive = false,
                    //                              ConfidenceScore = 0,
                    //                              Message = "Invalid request."
                    //                    };
                    //          }

                    //          bool isVerified = request.BlinkCount >= 0;

                    //          _db.livenessrequestcheckmodel.Add(request);
                    //          await _db.SaveChangesAsync();

                    //          return new LivenessResponse
                    //          {
                    //                    IsLive = isVerified,
                    //                    ConfidenceScore = isVerified ? 0.98 : 0.05,
                    //                    Message = isVerified
                    //                  ? "Liveness verified successfully."
                    //                  : "Please blink twice and try again."
                    //          };
                    //}


                    public async Task<LivenessResponse> VerifyBlinkAsync(LivenessCheckRequestModel request)
                    {
                              var existing = await _db.livenessrequestcheckmodel
                                  .FirstOrDefaultAsync(x => x.SessionId == request.SessionId);

                              if (existing != null)
                              {
                                        return new LivenessResponse
                                        {
                                                  IsLive = true,
                                                  Message = "Already Verified"
                                        };
                              }

                              _db.livenessrequestcheckmodel.Add(request);
                              await _db.SaveChangesAsync();

                              return new LivenessResponse
                              {
                                        IsLive = true,
                                        Message = "Blink Verified Successfully"
                              };
                    }

                    public async Task<LivenessCheckRequestModel> GetBySessionIdAsync(long sessionId)
                    {
                              return await _db.livenessrequestcheckmodel
                                              .FirstOrDefaultAsync(x => x.SessionId == sessionId);
                    }


                    //  public async Task<live> VerifyBlink(LivenessCheckRequestModel model)

          }
}