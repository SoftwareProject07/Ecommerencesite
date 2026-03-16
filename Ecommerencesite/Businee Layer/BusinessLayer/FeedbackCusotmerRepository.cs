using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class FeedbackCusotmerRepository : IFeedbackCusotmerRepository
          {
                    public readonly Ecommerecewebstedatabase _dbContext;
                    public FeedbackCusotmerRepository(Ecommerecewebstedatabase dbContext)
                    {
                              this._dbContext = dbContext;

                    }
                    public ResponseModel AddFeedback(FeedbackCusotmerModel feedback)
                    {
                              var response = new ResponseModel();
                              try
                              {
                                        _dbContext.feedbackCusotmerModels.Add(feedback);
                                        _dbContext.SaveChanges();
                                        response.status = true;
                                        response.responseMessage = "Feedback added successfully.";
                              }
                              catch (Exception ex)
                              {
                                        response.status = false;
                                        response.responseMessage = $"Error adding feedback: {ex.Message}";
                              }
                              return response;
                    }



                    public ResponseModel GetAllFeedbacks()
                    {
                            var response = new ResponseModel();
                              try
                              {
                                        var feedbacks = _dbContext.feedbackCusotmerModels.ToList();
                                        response.status = true;
                                        response.responseMessage = "Feedbacks retrieved successfully.";
                                        response.LSTfeedbackCusotmerModels = feedbacks;
                              }
                              catch (Exception ex)
                              {
                                        response.status = false;
                                        response.responseMessage = $"Error retrieving feedbacks: {ex.Message}";
                              }
                              return response;    
                    }
          }

}
