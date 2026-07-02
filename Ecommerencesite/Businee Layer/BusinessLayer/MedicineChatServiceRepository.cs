using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using System.Diagnostics;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class MedicineChatServiceRepository : IMedicineChatServiceRepository
          {
                    // public readonly Ecommerecewebstedatabase _dbcontext;
                    private  readonly IMedicineRepository _repository;
                    private readonly IAIService _ai;

                    public MedicineChatServiceRepository(IMedicineRepository repository, IAIService aiService)
                    {
                              this._repository = repository;
                              this.   _ai= aiService;
                    }





                    //public async Task<MedicineResponseDTO> AskQuestion(MedicineQueryDTO model)
                    //{
                    //          var medicine = await _repository.GetAnswerAsync(model.Question);

                    //          string answer = medicine != null
                    //              ? medicine.Answer
                    //              : "Sorry, I couldn't find an answer.";

                    //          await _repository.SaveChat(new MedicineChat
                    //          {
                    //                    CustomerName = model.CustomerName,
                    //                    Question = model.Question,
                    //                    Answer = answer,
                    //                    CreatedDate = DateTime.UtcNow
                    //          });

                    //          return new MedicineResponseDTO
                    //          {
                    //                    Success = true,
                    //                    Question = model.Question,
                    //                    Answer = answer,
                    //                    ResponseTime = DateTime.UtcNow
                    //          };
                    //}



                    public async Task<MedicineResponseDTO> AskQuestion(MedicineQueryDTO model)
                    {
                              if (model == null)
                              {
                                        return new MedicineResponseDTO
                                        {
                                                  Success = false,
                                                  Answer = "Invalid request.",
                                                  ResponseTime = DateTime.UtcNow
                                        };
                              }

                              if (string.IsNullOrWhiteSpace(model.Question))
                              {
                                        return new MedicineResponseDTO
                                        {
                                                  Success = false,
                                                  Answer = "Please enter your question.",
                                                  ResponseTime = DateTime.UtcNow
                                        };
                              }

                              // Get answer from AI
                              string answer = await _ai.GenerateAnswerAsync(model.Question);

                              // Save chat history
                              await _repository.SaveChat(new MedicineChat
                              {
                                        CustomerName = model.CustomerName,
                                        Question = model.Question,
                                        Answer = answer,
                                        CreatedDate = DateTime.UtcNow
                              });

                              // Return response
                              return new MedicineResponseDTO
                              {
                                        Success = true,
                                        Question = model.Question,
                                        Answer = answer,
                                        ResponseTime = DateTime.UtcNow
                              };
                    }
          }
}
