using Ecommerencesite.Businee_Layer.IBusineeLayer;
using HelpDeskAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



          namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class TicketAPIController : ControllerBase
          {
                    public  readonly ITicketServiceRepository _ticketService;

                    public TicketAPIController(ITicketServiceRepository ticketService)
                    {
                           this.   _ticketService = ticketService;
                    }

                    // Raise Ticket
                    // Raise Ticket
                    [HttpPost("RaiseTicket")]
                    public async Task<IActionResult> RaiseTicket([FromBody] CustomerTicketRaiseModel model)
                    {
                              if (!ModelState.IsValid)
                                        return BadRequest(ModelState);

                              var result = await _ticketService.RaiseTicket(model);

                              return Ok(result);
                    }

                    // Get All Tickets
                    [HttpGet("GetAllTickets")]
                    public async Task<IActionResult> GetAllTickets()
                    {
                              var result = await _ticketService.GetAllTickets();

                              return Ok(result);
                    }

                    // Get Ticket By Id
                    [HttpGet("GetTicketById/{id}")]
                    public async Task<IActionResult> GetTicketById(int id)
                    {
                              var result = await _ticketService.GetTicketById(id);

                              if (result == null)
                                        return NotFound("Ticket Not Found");

                              return Ok(result);
                    }

                    // Get Ticket By Customer
                    [HttpGet("GetTicketByCustomer/{customerId}")]
                    public async Task<IActionResult> GetTicketByCustomer(string customerId)
                    {
                              var result = await _ticketService.GetTicketByCustomer(customerId);

                              return Ok(result);
                    }

                    // Get Ticket By Status
                    [HttpGet("GetTicketByStatus/{status}")]
                    public async Task<IActionResult> GetTicketByStatus(string status)
                    {
                              var result = await _ticketService.GetTicketByStatus(status);

                              return Ok(result);
                    }

                    // Get Ticket By Issue Type
                    [HttpGet("GetTicketByIssueType/{issueType}")]
                    public async Task<IActionResult> GetTicketByIssueType(string issueType)
                    {
                              var result = await _ticketService.GetTicketByIssueType(issueType);

                              return Ok(result);
                    }

                    // Update Ticket
                    [HttpPut("UpdateTicket")]
                    public async Task<IActionResult> UpdateTicket([FromBody] CustomerTicketRaiseModel model)
                    {
                              if (!ModelState.IsValid)
                                        return BadRequest(ModelState);

                              var result = await _ticketService.UpdateTicket(model);

                              return Ok(result);
                    }

                    // Delete Ticket
                    [HttpDelete("DeleteTicket/{id}")]
                    public async Task<IActionResult> DeleteTicket(int id)
                    {
                              var result = await _ticketService.DeleteTicket(id);

                              return Ok(result);
                    }

                    // Close Ticket
                    [HttpPut("CloseTicket/{ticketId}")]
                    public async Task<IActionResult> CloseTicket(int ticketId, [FromQuery] string remark)
                    {
                              var result = await _ticketService.CloseTicket(ticketId, remark);

                              return Ok(result);
                    }
          }
}
