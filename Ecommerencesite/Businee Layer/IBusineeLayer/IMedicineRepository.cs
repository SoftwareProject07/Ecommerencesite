using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IMedicineRepository
          {
                    // Task<string> GetAnswer(string question);
                    Task<MedicineChat> GetAnswerAsync(string question);

                    Task SaveChat(MedicineChat chat);


          }
}
