using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class FeedbackCustomerApiController : ControllerBase
          {
                    private readonly IFeedbackCusotmerRepository _feedbackRepository;
                    public FeedbackCustomerApiController(IFeedbackCusotmerRepository feedbackRepository)
                    {
                              this._feedbackRepository = feedbackRepository;
                    }
                    [HttpPost("AddFeedback")]
                    public IActionResult AddFeedback(FeedbackCusotmerModel feedback)
                    {
                              try
                              {
                                        _feedbackRepository.AddFeedback(feedback);
                                        return Ok("Feedback added successfully.");
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }
                    [HttpGet("GetAllFeedbacks")]
                    public IActionResult GetAllFeedbacks()
                    {
                              try
                              {
                                        var feedbacks = _feedbackRepository.GetAllFeedbacks();
                                        return Ok(feedbacks);
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }

          }
}
