using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class MedicineRepositoryAPIController : ControllerBase
          {
                    private readonly IMedicineRepository _repository;
                    public MedicineRepositoryAPIController(IMedicineRepository repository)
                    {
                              this._repository = repository;
                    }


                    // GET: api/MedicineRepository/GetAnswer?question=fever
                    [HttpGet("GetAnswer")]
                    public async Task<IActionResult> GetAnswer(string question)
                    {
                              if (string.IsNullOrWhiteSpace(question))
                              {
                                        return BadRequest("Please enter a question.");
                              }

                              var result = await _repository.GetAnswerAsync(question);

                              if (result == null)
                              {
                                        return NotFound("No answer found.");
                              }

                              return Ok(result);
                    }

                    // POST: api/MedicineRepository/SaveChat
                    [HttpPost("SaveChat")]
                    public async Task<IActionResult> SaveChat([FromBody] MedicineChat chat)
                    {
                              if (chat == null)
                              {
                                        return BadRequest("Invalid request.");
                              }

                              await _repository.SaveChat(chat);

                              return Ok(new
                              {
                                        Success = true,
                                        Message = "Chat saved successfully."
                              });
                    }
          }
}
