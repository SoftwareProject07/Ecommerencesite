namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IAIService
          {
                    //  Task<string> GenerateAnswerAsync(string question);
                    Task<string> GenerateAnswerAsync(string question, string orderNumber = null);
          }
}
