using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IMedicineChatServiceRepository
          {
                    Task<MedicineResponseDTO> AskQuestion(MedicineQueryDTO model);

                //    Task<string> GenerateAnswerAsync(string question);


          }
}
