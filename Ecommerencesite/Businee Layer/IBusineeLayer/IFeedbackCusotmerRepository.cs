using Ecommerencesite.Model;
using Twilio.Http;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IFeedbackCusotmerRepository
          {
                    public ResponseModel AddFeedback(FeedbackCusotmerModel feedback);//customer side
                    public ResponseModel GetAllFeedbacks();//Admin side

          }
}
