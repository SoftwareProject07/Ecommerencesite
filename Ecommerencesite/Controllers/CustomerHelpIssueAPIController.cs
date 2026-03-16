using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class CustomerHelpIssueAPIController : ControllerBase
          {
                    private readonly ICustomerHelpIssueRepository _customerHelpIssueRepository;
                    public CustomerHelpIssueAPIController(ICustomerHelpIssueRepository customerHelpIssueRepository)
                    {
                              this._customerHelpIssueRepository = customerHelpIssueRepository;
                    }
                    [HttpPost("AddCustomerHelpIssue")]
                    public IActionResult AddCustomerHelpIssue(CustomerHelpIssueModel customerHelpIssue)
                    {
                              try
                              {
                                        var response = _customerHelpIssueRepository.AddCustomerHelpIssue(customerHelpIssue);
                                        if (response.status)
                                        {
                                                  return Ok(response.responseMessage);
                                        }
                                        else
                                        {
                                                  return BadRequest(response.responseMessage);
                                        }
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }

                    [HttpGet("GetAllCustomerHelpIssues")]
                    public IActionResult GetAllCustomerHelpIssues()
                    {
                              try
                              {
                                        var response = _customerHelpIssueRepository.GetAllCustomerHelpIssues();
                                        if (response.status)
                                        {
                                                  return Ok(response.Data);
                                        }
                                        else
                                        {
                                                  return BadRequest(response.responseMessage);
                                        }
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }
          }
}
