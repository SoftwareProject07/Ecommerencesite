using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class CustomerCareTicketAPIController : ControllerBase
          {
                    public readonly ICustomerCareticketrepository _customerCareTicketRepository;
                    public CustomerCareTicketAPIController(ICustomerCareticketrepository customerCareTicketRepository)
                    {
                              _customerCareTicketRepository = customerCareTicketRepository;
                    }
                    [HttpPost("chat")]
                    public async Task<IActionResult> PostChat([FromBody] ChatRequest request)
                    {
                              if (request == null) return BadRequest("Invalid request.");

                              var responseMessage = await _customerCareTicketRepository.ProcessAiChat(request);

                              return Ok(new
                              {
                                        reply = responseMessage,
                                        timestamp = DateTime.Now
                              });
                    }


                    //[HttpPost("ai-chat")]
                    //public async Task<IActionResult> AskAi([FromBody] ChatRequest request)
                    //{
                    //          if (request == null) return BadRequest();

                    //          var reply = await _careService.GetAiResponseAsync(request);
                    //          return Ok(new { reply, timestamp = DateTime.Now });
                    //}
          }

}
