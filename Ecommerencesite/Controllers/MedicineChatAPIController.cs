using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class MedicineChatAPIController : ControllerBase
          {
                    private readonly IMedicineChatServiceRepository service;
                    public MedicineChatAPIController(IMedicineChatServiceRepository _service)
                    {
                              this.service = _service;      
                    }




                    //[HttpPost("AskQuestion")]
                    //public async Task<IActionResult> AskQuestion([FromBody] MedicineQueryDTO model)
                    //{
                    //          try
                    //          {
                    //                    if (model == null)
                    //                    {
                    //                              return BadRequest(new
                    //                              {
                    //                                        Success = false,
                    //                                        Message = "Request cannot be null."
                    //                              });
                    //                    }

                    //                    if (string.IsNullOrWhiteSpace(model.Question))
                    //                    {
                    //                              return BadRequest(new
                    //                              {
                    //                                        Success = false,
                    //                                        Message = "Please enter your question."
                    //                              });
                    //                    }

                    //                    var response = await service.AskQuestion(model);

                    //                    return Ok(response);
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    //                    {
                    //                              Success = false,
                    //                              Message = ex.Message
                    //                    });
                    //          }



                    //[HttpPost("AskQuestion")]
                    //public async Task<IActionResult> AskQuestion(MedicineQueryDTO model)
                    //{
                    //          var result = await service.AskQuestion(model);

                    //          return Ok(result);
                    //}


                    [HttpPost("AskQuestion")]
                    public async Task<IActionResult> AskQuestion([FromBody] MedicineQueryDTO model)
                    {
                              if (model == null || string.IsNullOrWhiteSpace(model.Question))
                              {
                                        return BadRequest(new
                                        {
                                                  Success = false,
                                                  Message = "Please enter a question."
                                        });
                              }

                              var result = await service.AskQuestion(model);

                              return Ok(result);
                    }
          }



                    //[HttpPost("AskQuestion")]
                    //public async Task<IActionResult> AskQuestion(MedicineQueryDTO model)
                    //{
                    //          var result = await service.AskQuestion(model);
                    //          return Ok(result);
                    //}

                    //[HttpGet("GetChatHistory")]
                    //public async Task<IActionResult> GetChatHistory()
                    //{
                    //          var result = await service.GetChatHistory();
                    //          return Ok(result);
                    //}

                    //[HttpGet("GetChatById/{id}")]
                    //public async Task<IActionResult> GetChatById(int id)
                    //{
                    //          var result = await service.Ge(id);

                    //          if (result == null)
                    //                    return NotFound();

                    //          return Ok(result);
                    //}

                    //[HttpDelete("DeleteChat/{id}")]
                    //public async Task<IActionResult> DeleteChat(int id)
                    //{
                    //          var result = await _service.DeleteChat(id);

                    //          if (!result)
                    //                    return NotFound();

                    //          return Ok("Deleted Successfully");
                    //}

                    //[HttpDelete("DeleteAllChats")]
                    //public async Task<IActionResult> DeleteAllChats()
                    //{
                    //          await service.DeleteAllChats();
                    //          return Ok("All Chats Deleted Successfully");
                    //}
          }

