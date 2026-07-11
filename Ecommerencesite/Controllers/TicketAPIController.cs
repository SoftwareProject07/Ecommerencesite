using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.MODELDTO;
using HelpDeskAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class TicketAPIController : ControllerBase
          {
                    public readonly ITicketServiceRepository _ticketService;

                    public TicketAPIController(ITicketServiceRepository ticketService)
                    {
                              this._ticketService = ticketService;
                    }

                    // Raise Ticket
                    // Raise Ticket
                    [HttpPost("RaiseTicket")]
                    public async Task<IActionResult> RaiseTicket(CustomerTicketRaiseModel model)
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
                    //[HttpPut("UpdateTicket")]
                    //public async Task<IActionResult> UpdateTicket(CustomerTicketRaiseModel model)
                    //{
                    //          if (!ModelState.IsValid)
                    //                    return BadRequest(ModelState);

                    //          var result = await _ticketService.UpdateTicket(model);

                    //          return Ok(result);
                    //}
                    //[HttpPut("UpdateTicket")]
                    //public void Updateticket(CustomerTicketRaiseModel model)
                    //{
                    //          _ticketService.Updateticket(model);

                    //}


                    //[HttpPut("Update/{id}")]
                    //public IActionResult Updateticket(int id,  CustomerTicketRaiseModel payload)
                    //{
                    //          if (payload == null || string.IsNullOrWhiteSpace(payload.DepartmentOption))
                    //          {
                    //                    return BadRequest("Invalid assignment request data.");
                    //          }

                    //          // 1. Fetch the full original ticket row tracking model from the database using the route ID
                    //          var existingTicket = _ticketService.GetTicketById(id).Result; // Assuming GetTicketByStatus returns a Task<CustomerTicketRaiseModel>

                    //          if (existingTicket == null)
                    //          {
                    //                    return NotFound($"Ticket entity with ID {id} not found.");
                    //          }

                    //          // 2. Modify only the required structural fields matching your CustomerTicketRaiseModel
                    //          existingTicket.AssignedTo = payload.DepartmentOption;
                    //          existingTicket.UpdatedDate = DateTime.UtcNow;

                    //          // 3. Hand over the entire validated model structure to your original service logic 
                    //          _ticketService.Updateticket(existingTicket);

                    //          return Ok(new { success = true, message = "Ticket successfully assigned." });
                    //}



                    //// ASSIGN TASK TEAM 
                    [HttpPut("Update/{id}")]
                    public IActionResult Assignedticket(int id, CustomerTicketRaiseModel payload)
                    {
                              if (payload == null) return BadRequest("Invalid request payload.");

                              try
                              {
                                        // Construct a light model containing just the update field parameters
                                        var updatedModel = new CustomerTicketRaiseModel
                                        {
                                                  AssignedTo = payload.AssignedTo,
                                                  Status = "Assigned"

                                        };

                                        // Call your corrected business service method
                                        _ticketService.Updateticket(id, updatedModel);

                                        return Ok(new { success = true, message = "Database entity state pipeline updated successfully!" });
                              }
                              catch (Exception ex)
                              {
                                        return BadRequest(new { success = false, message = ex.Message });
                              }
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
                    [HttpPost("MasterAddIssuecategory")]
                    public void MasterAddIssuecategory(CustomerTicketRaiseModel issuecategory)
                    {
                              _ticketService.MasterAddIssuecategory(issuecategory);
                    }

             
                   

                    [HttpPut("MasterUPDATEIssuecategory")]
                    // 💡 यहाँ पैरामीटर से पहले [FromBody] जोड़ दिया गया है
                    public IActionResult MasterUPDATEIssuecategory(CustomerTicketRaiseModel UPdatecategory)
                    {
                              // 1. Validation check
                              if (UPdatecategory == null)
                              {
                                        return BadRequest("Data cannot be null");
                              }

                              try
                              {
                                        // 2. Service call
                                        _ticketService.MasterUPDATEIssuecategory(UPdatecategory);

                                        // 3. Success Response return karna
                                        return Ok(new { message = "Item category updated successfully!" });
                              }
                              catch (Exception ex)
                              {
                                        // 4. Koi error aaye toh handle karna
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }
                    [HttpGet("MasterGetIssuecategoryById/{id}")]
                    public CustomerTicketRaiseModel MasterGetIssuecategoryById(int id)
                    {
                              return _ticketService.MasterGetIssuecategoryById(id);
                    }

                    [HttpDelete("MasterDeleteissuecategory/{id}")]
                    public CustomerTicketRaiseModel MasterDeleteissuecategory(int id)
                    {
                              return _ticketService.MasterDeleteissuecategory(id);

                    }
                

                    [HttpGet("MasterGetAllIssuecategory")]
                    public IActionResult MasterGetAllIssuecategory()
                    {
                              try
                              {
                                        var data = _ticketService.MasterGetAllIssuecategory();
                                        return Ok(data);
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }

                    [HttpPost("MasterAddAssignticket")]
                    public void MasterAddAssignticket(CustomerTicketRaiseModel assignticket)
                    {
                              _ticketService.MasterAddAssignticket(assignticket);

                    }
                    [HttpGet("MasterAllAssignticket")]
                    public IActionResult MasterAllAssignticket()
                    {
                              try
                              {
                                        var data = _ticketService.MasterAllAssignticket();
                                        return Ok(data);
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }
                    [HttpPut("MasterUpdateAssignticket")]

                    public IActionResult MasterUpdateAssignticket(CustomerTicketRaiseModel customerTicketRaiseModel)
                    {

                              //   _ticketService.MasterUpdateAssignticket(customerTicketRaiseModel);


                              // 1. Validation check
                              if (customerTicketRaiseModel == null)
                              {
                                        return BadRequest("Data cannot be null");
                              }

                              try
                              {
                                        // 2. Service call
                                        _ticketService.MasterUpdateAssignticket(customerTicketRaiseModel);

                                        // 3. Success Response return karna
                                        return Ok(new { message = "Assigned to  category updated successfully!" });
                              }
                              catch (Exception ex)
                              {
                                        // 4. Koi error aaye toh handle karna
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }



                    [HttpGet("MasterGetAssignticketById")]
                    public CustomerTicketRaiseModel MasterGetAssignticketById(int assgingetid)
                    {
                              return _ticketService.MasterGetAssignticketById(assgingetid);

                    }
                    [HttpDelete("MasterDeleteAssignticket")]
                    public CustomerTicketRaiseModel MasterDeleteAssignticket(int deleteassignid)
                    {
                              return _ticketService.MasterDeleteAssignticket(deleteassignid);
                    }

          }
}
