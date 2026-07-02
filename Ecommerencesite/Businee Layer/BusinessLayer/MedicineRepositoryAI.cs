using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class MedicineRepositoryAI : IMedicineRepository
          {
                    public readonly Ecommerecewebstedatabase _context;
                    public MedicineRepositoryAI(Ecommerecewebstedatabase context)
                    {
                              this._context = context;
                    }

                    public async Task SaveChat(MedicineChat chat)
                    {
                              _context.MedicineChats.Add(chat);
                              await _context.SaveChangesAsync();
                    }

                    //public async Task<string> GetAnswer(string question)
                    //{
                    //          question = question.ToLower();

                    //          if (question.Contains("paracetamol"))
                    //                    return "Paracetamol is commonly used to reduce fever and relieve mild to moderate pain. Use it according to the label or your doctor's advice.";

                    //          if (question.Contains("fever"))
                    //                    return "For fever, medicines containing Paracetamol are commonly used. If the fever persists for more than 2–3 days or is severe, consult a doctor.";

                    //          if (question.Contains("headache"))
                    //                    return "Headaches can have many causes. Rest, hydration, and appropriate pain relief may help. Seek medical advice if headaches are severe or persistent.";

                    //          if (question.Contains("cough"))
                    //                    return "The appropriate treatment depends on whether the cough is dry or productive. Please consult a healthcare professional if symptoms persist.";

                    //          if (question.Contains("delivery"))
                    //                    return "Medicine delivery is available. Orders are generally delivered within 24–48 hours, depending on your location.";

                    //          if (question.Contains("refund"))
                    //                    return "Refunds are processed after verification in accordance with our return policy.";

                    //          return "I'm sorry, I couldn't find a specific answer. Please contact our pharmacist or customer support for further assistance.";
                    //}


                    // Get answer from database
                    public async Task<MedicineChat> GetAnswerAsync(string question)
                    {
                              if (string.IsNullOrWhiteSpace(question))
                                        return null;

                              question = question.Trim().ToLower();

                              return await _context.MedicineChats
                                  .Where(x => x.Question.ToLower().Contains(question)
                                           || question.Contains(x.Question.ToLower()))
                                  .FirstOrDefaultAsync();
                    }
          }
}
