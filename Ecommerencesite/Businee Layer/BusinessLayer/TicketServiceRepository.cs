using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.MODELDTO;
using HelpDeskAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class TicketServiceRepository : ITicketServiceRepository
          {
                    private readonly Ecommerecewebstedatabase _context;

                    public TicketServiceRepository(Ecommerecewebstedatabase context)
                    {
                              _context = context;
                    }

                    // Raise Ticket
                    //public async Task<string> RaiseTicket(CustomerTicketRaiseModel model)
                    //{
                    //          model.CreatedDate = DateTime.UtcNow;
                    //          model.Status = "Open";

                    //          model.TicketNumber = "TKT" + DateTime.Now.ToString("yyyyMMddHHmmss");

                    //          await _context.CustomerTicketRaise.AddAsync(model);
                    //          await _context.SaveChangesAsync();

                    //          return $"Ticket Raised Successfully.. +  "  
                    //                    $" Ticket No : {model.TicketNumber}" ;
                    //}

                    public async Task<string> RaiseTicket(CustomerTicketRaiseModel model)
                    {
                              model.CreatedDate = DateTime.UtcNow;
                              model.Status = "Open";

                              model.TicketNumber = "TKT" + DateTime.Now.ToString("yyyyMMddHHmmss");

                              await _context.CustomerTicketRaise.AddAsync(model);
                              await _context.SaveChangesAsync();

                              // <br> टैग के बाद "Please wait..." को अगली लाइन में जोड़ दिया गया है
                              return $"Ticket Raised Successfully... " +
                                     $"Ticket No : {model.TicketNumber}  " +
                                     $"Please wait  Coming Soon...";
                    }

                    // Get All Tickets
                    public async Task<List<CustomerTicketRaiseModel>> GetAllTickets()
                    {
                              return await _context.CustomerTicketRaise
                                  .OrderByDescending(x => x.CreatedDate)
                                  .ToListAsync();
                    }

                    // Get Ticket By Id
                    public async Task<CustomerTicketRaiseModel> GetTicketById(int id)
                    {
                              return await _context.CustomerTicketRaise
                                  .FirstOrDefaultAsync(x => x.TicketId == id);
                    }

                    // Get Ticket By Customer
                    public async Task<List<CustomerTicketRaiseModel>> GetTicketByCustomer(string customerId)
                    {
                              return await _context.CustomerTicketRaise
                                  .Where(x => x.CustomerId == customerId)
                                  .ToListAsync();
                    }

                    // Get Ticket By Status
                    public async Task<List<CustomerTicketRaiseModel>> GetTicketByStatus(string status)
                    {
                              return await _context.CustomerTicketRaise
                                  .Where(x => x.Status == status)
                                  .ToListAsync();
                    }

                    // Get Ticket By Issue Type
                    public async Task<List<CustomerTicketRaiseModel>> GetTicketByIssueType(string issueType)
                    {
                              return await _context.CustomerTicketRaise
                                  .Where(x => x.IssueCategory == issueType)
                                  .ToListAsync();
                    }

                    // Update Ticket
                    //public async Task<string> UpdateTicket(CustomerTicketRaiseModel model)
                    //{
                    //          var ticket = await _context.CustomerTicketRaise
                    //              .FirstOrDefaultAsync(x => x.TicketId == model.TicketId);

                    //          if (ticket == null)
                    //                    return "Ticket Not Found";

                    //          ticket.CustomerName = model.CustomerName;
                    //          ticket.CustomerId = model.CustomerId;
                    //          ticket.MobileNo = model.MobileNo;
                    //          ticket.Email = model.Email;
                    //          ticket.OrderId = model.OrderId;
                    //          ticket.MedicineName = model.MedicineName;
                    //          ticket.IssueCategory = model.IssueCategory;
                    //          ticket.Subject = model.Subject;
                    //          ticket.Description = model.Description;
                    //          ticket.Priority = model.Priority;
                    //          ticket.Status = model.Status;
                    //          ticket.Attachment = model.Attachment;
                    //          ticket.AssignedTo = model.AssignedTo;
                    //          ticket.ResolutionRemark = model.ResolutionRemark;
                    //          ticket.UpdatedDate = DateTime.Now;

                    //          await _context.SaveChangesAsync();

                    //          return "Ticket Updated Successfully";
                    //}

                    // Delete Ticket
                    public async Task<string> DeleteTicket(int id)
                    {
                              var ticket = await _context.CustomerTicketRaise
                                  .FirstOrDefaultAsync(x => x.TicketId == id);

                              if (ticket == null)
                                        return "Ticket Not Found";

                              _context.CustomerTicketRaise.Remove(ticket);
                              await _context.SaveChangesAsync();

                              return "Ticket Deleted Successfully";
                    }

                    // Close Ticket
                    public async Task<string> CloseTicket(int ticketId, string remark)
                    {
                              var ticket = await _context.CustomerTicketRaise
                                  .FirstOrDefaultAsync(x => x.TicketId == ticketId);

                              if (ticket == null)
                                        return "Ticket Not Found";

                              ticket.Status = "Closed";
                              ticket.ResolutionRemark = remark;
                              ticket.ClosedDate = DateTime.Now;

                              await _context.SaveChangesAsync();

                              return "Ticket Closed Successfully";
                    }

                    // ASSIGN TASK TEAM 
                    public void Updateticket(int id, CustomerTicketRaiseModel model)
                    {
                              // 1. Fetch the original untampered record from the database
                              var existingTicket = _context.CustomerTicketRaise.Find(id);

                              if (existingTicket == null)
                              {
                                        throw new Exception($"Validation Error: Ticket with ID {id} does not exist in the database state pipeline.");
                              }

                              // 2. Map ONLY the properties that are allowed to change during an assignment update
                              existingTicket.AssignedTo = model.AssignedTo;
                              existingTicket.Status = model.Status ?? existingTicket.Status; // Fallback to current state if null
                              existingTicket.UpdatedDate = DateTime.UtcNow; // Record audit time

                              // Note: Because EF Core tracks 'existingTicket', we DO NOT need to call _context.Update()!
                              // It automatically computes what fields changed.

                              // 3. Commit changes safely
                              _context.SaveChanges();
                    }

                    public void MasterAddIssuecategory(CustomerTicketRaiseModel issuecategory)
                    {
                              _context.CustomerTicketRaise.Add(issuecategory);
                              _context.SaveChanges();
                    }

                    public void MasterUPDATEIssuecategory(CustomerTicketRaiseModel UPdatecategory)
                    {
                              _context.CustomerTicketRaise.Update(UPdatecategory);
                              _context.SaveChanges();
                    }

                    public CustomerTicketRaiseModel MasterGetIssuecategoryById(int id)
                    {
                              var issuecategory = _context.CustomerTicketRaise.FirstOrDefault(x => x.TicketId == id);
                              return issuecategory;
                    }

                    public CustomerTicketRaiseModel MasterDeleteissuecategory(int id)
                    {
                             var a= _context.CustomerTicketRaise.FirstOrDefault(x => x.TicketId == id);
                              if (a != null)
                              {
                                        _context.CustomerTicketRaise.Remove(a);
                                        _context.SaveChanges();
                              }
                              return a;
                    }

                    public List<itemcategorymasterlstdto> MasterGetAllIssuecategory()
                    {
                              return _context.CustomerTicketRaise
                                             .Select(x => new itemcategorymasterlstdto
                                             {
                                                        issuecategorymasterid=x.TicketId,
                                                      
                                                       IssueCategory = x.IssueCategory
                                             })
                                             .Distinct()
                                             .ToList();

                    }
                    //    public async Task<bool> SendAssignmentUpdateAsync(string mobileNumber, string ticketId, string AssignedTo)
                    //    {
                    //              // WhatsApp API URL (Apne Phone Number ID ke sath replace karein)
                    //              string url = "[https://graph.facebook.com/v17.0/YOUR_PHONE_NUMBER_ID/messages](https://graph.facebook.com/v17.0/YOUR_PHONE_NUMBER_ID/messages)";
                    //              string accessToken = "YOUR_META_PERMANENT_ACCESS_TOKEN";

                    //              using (var client = new HttpClient())
                    //              {
                    //                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    //                        // WhatsApp Template Payload
                    //                        var payload = new
                    //                        {
                    //                                  messaging_product = "whatsapp",
                    //                                  to = mobileNumber.StartsWith("91") ? mobileNumber : "91" + mobileNumber, // India country code handling
                    //                                  type = "template",
                    //                                  template = new
                    //                                  {
                    //                                            name = "ticket_assignment_update", // Aapke Meta dashboard me approved template ka naam
                    //                                            language = new { code = "en_US" },
                    //                                            components = new[]
                    //                                {
                    //    new
                    //    {
                    //        type = "body",
                    //        parameters = new[]
                    //        {
                    //            new { type = "text", text = ticketId },     // Template Variable {{1}}
                    //            new { type = "text", text = AssignedTo }   // Template Variable {{2}}
                    //        }
                    //    }
                    //}
                    //                                  }
                    //                        };

                    //                        string jsonPayload = JsonSerializer.Serialize(payload);
                    //                        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    //                        var response = await client.PostAsync(url, content);
                    //                        return response.IsSuccessStatusCode;
                    //              }
                    //    }
          }
}
