using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using HelpDeskAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class TicketServiceRepository : ITicketServiceRepository
          {
                    private readonly Ecommerecewebstedatabase _context;
                    private readonly IHttpClientFactory _httpClientFactory;
                    public TicketServiceRepository(Ecommerecewebstedatabase context, IHttpClientFactory httpClientFactory)
                    {
                              this._context = context;
                              this._httpClientFactory = httpClientFactory;
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



                    // ASSIGN TASK TEAM work
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





                    public void MasterAddIssuecategory(IssueCategorymasterModel issuecategory)
                    {
                              _context.issuecategorymasterModels.Add(issuecategory);
                              _context.SaveChanges();
                    }

                    //public void MasterUPDATEIssuecategory(CustomerTicketRaiseModel UPdatecategory)
                    //{
                    //          _context.CustomerTicketRaise.Update(UPdatecategory);
                    //          _context.SaveChanges();
                    //}


                    public void MasterUPDATEIssuecategory(IssueCategorymasterModel UPdatecategory)
                    {
                              // 1. Database se existing record nikalein uski Id se
                              var existingTicket = _context.issuecategorymasterModels
                                                           .FirstOrDefault(x => x.issuecategorymasterid == UPdatecategory.issuecategorymasterid);

                              if (existingTicket != null)
                              {
                                        // 2. Kewal ItemCategory ko naye value se replace karein
                                        existingTicket.IssueCategory = UPdatecategory.IssueCategory;

                                        // 3. Save karein
                                        _context.SaveChanges();
                              }
                    }

                    public IssueCategorymasterModel MasterGetIssuecategoryById(int id)
                    {
                              var issuecategory = _context.issuecategorymasterModels.FirstOrDefault(x => x.issuecategorymasterid == id);
                              return issuecategory;
                    }

                    public IssueCategorymasterModel MasterDeleteissuecategory(int id)
                    {
                              var a = _context.issuecategorymasterModels.FirstOrDefault(x => x.issuecategorymasterid == id);
                              if (a != null)
                              {
                                        _context.issuecategorymasterModels.Remove(a);
                                        _context.SaveChanges();
                              }
                              return a;
                    }

                    public List<IssueCategorymasterModel> MasterGetAllIssuecategory()
                    {
                              //return _context.CustomerTicketRaise
                              //               .Select(x => new itemcategorymasterlstdto
                              //               {
                              //                          issuecategorymasterid=x.TicketId,

                              //                         IssueCategory = x.IssueCategory
                              //               })
                              //               .Distinct()
                              //               .ToList();

                              return _context.issuecategorymasterModels
                                                            .Select(x => new IssueCategorymasterModel
                                                            {
                                                                      issuecategorymasterid = x.issuecategorymasterid,
                                                                      IssueCategory = x.IssueCategory
                                                            })
                                                            .Distinct()
                                                            .ToList();

                    }

                    public void MasterAddAssignticket(AssignRaiseTicketModel assignticket)
                    {
                              _context.AssignRaiseTicket.Add(assignticket);
                              _context.SaveChanges();
                              //var ADDASSING = _context.CustomerTicketRaise.FirstOrDefault(x => x.TicketId == assignticket.TicketId);
                              //if (ADDASSING != null)
                              //{
                              //          ADDASSING.AssignedTo = assignticket.AssignedTo;


                              //}
                              //_context.CustomerTicketRaise.Add(ADDASSING);
                              //_context.SaveChanges();
                    }

                    public void MasterUpdateAssignticket(AssignRaiseTicketModel customerTicketRaiseModel)
                    {
                              //_context.CustomerTicketRaise.Update(customerTicketRaiseModel);
                              //_context.SaveChanges();

                              // 1. Database se existing record nikalein uski Id se
                              var existingTicket = _context.AssignRaiseTicket
                                                           .FirstOrDefault(x => x.AssignId == customerTicketRaiseModel.AssignId);

                              if (existingTicket != null)
                              {
                                        // 2. Kewal ItemCategory ko naye value se replace karein
                                        existingTicket.AssignedTo = customerTicketRaiseModel.AssignedTo;

                                        // 3. Save karein
                                        _context.SaveChanges();
                              }
                    }

                    public AssignRaiseTicketModel MasterGetAssignticketById(int assgingetid)
                    {
                              var a = _context.AssignRaiseTicket.FirstOrDefault(x => x.AssignId == assgingetid);
                              return a;
                    }

                    public AssignRaiseTicketModel MasterDeleteAssignticket(int deleteassignid)
                    {
                              var deleteassign = _context.AssignRaiseTicket.Where(x => x.AssignId == deleteassignid).FirstOrDefault();
                              if (deleteassign != null)
                              {
                                        _context.AssignRaiseTicket.Remove(deleteassign);
                                        _context.SaveChanges();
                              }
                              return deleteassign;
                    }

                    public List<AssignRaiseTicketModel> MasterAllAssignticket()
                    {
                              //return _context.CustomerTicketRaise
                              //           .Select(x => new AssignRaiseTicketDto
                              //           {
                              //                     TicketId = x.TicketId,

                              //                     AssignedTo = x.AssignedTo
                              //           })
                              //           .Distinct()
                              //           .ToList();
                              return _context.AssignRaiseTicket
                                                            .Select(x => new AssignRaiseTicketModel
                                                            {
                                                                      AssignId = x.AssignId,
                                                                      AssignedTo = x.AssignedTo
                                                            })
                                                            .Distinct()
                                                            .ToList();

                    }
                  

                    //public async Task<bool> AssignTicketAsync(int id, TicketUpdateDto model)
                    //{
                    //          // 1. Fetch Target Entity
                    //          var ticket = await _context.CustomerTicketRaise.FindAsync(id);
                    //          if (ticket == null) return false;

                    //          // 2. Data Modification Updates
                    //          ticket.AssignedTo = model.AssignedTo;
                    //          ticket.Status = "Assigned";

                    //          if (!string.IsNullOrEmpty(model.IssueCategory))
                    //          {
                    //                    ticket.IssueCategory = model.IssueCategory;
                    //          }

                    //          // Commit DB Changes
                    //          await _context.SaveChangesAsync();

                    //          // 3. Robust Data Fallback (Frontend empty values protection)
                    //          string targetMobile = !string.IsNullOrEmpty(model.MobileNo) ? model.MobileNo : ticket.MobileNo;
                    //          string issueCategory = !string.IsNullOrEmpty(model.IssueCategory) ? model.IssueCategory : ticket.IssueCategory;
                    //          string ticketNum = !string.IsNullOrEmpty(model.TicketNumber) ? model.TicketNumber : ticket.TicketNumber;

                    //          // Clean Mobile Number Pattern (Handles empty/null strings safely)
                    //          targetMobile = Regex.Replace(targetMobile ?? "", @"\D", "").Trim();

                    //          // Formatting: 12-digit number (with 91 prefix) ko 10-digit clean number me convert karne ke liye
                    //          if (targetMobile.StartsWith("91") && targetMobile.Length == 12)
                    //          {
                    //                    targetMobile = targetMobile.Substring(2);
                    //          }

                    //          // 4. Async Non-Blocking SMS Dispatch Channel
                    //          if (!string.IsNullOrEmpty(targetMobile) && targetMobile.Length == 10 && targetMobile != "0000000000")
                    //          {
                    //                    // ==================== CONFIGURATION ZONE ====================
                    //                    string gatewayApiKey = "85749302adfebc849201948573";
                    //                    string dltTemplateId = "1207167894561230495";
                    //                    string senderId = "AKMEDZ";
                    //                    // ============================================================

                    //                    // Clean template string format optimized for DLT validation engines
                    //                    string smsMessage = $"Dear Customer, your ticket {ticketNum} regarding {issueCategory} has been successfully assigned to {model.AssignedTo}. Update as soon. Team AKMedizo";

                    //                    // Use Uri.EscapeDataString instead of HttpUtility.UrlEncode to enforce standard %20 spacing rules
                    //                    string encodedMessage = Uri.EscapeDataString(smsMessage);

                    //                    string directSmsUrl = $"https://api.bulksmsgateway.in/send?apikey={gatewayApiKey}&to={targetMobile}&sender={senderId}&message={encodedMessage}&template_id={dltTemplateId}";

                    //                    var httpClient = _httpClientFactory.CreateClient();
                    //                    try
                    //                    {
                    //                              // Dispatch request to external network provider infrastructure
                    //                              var response = await httpClient.GetAsync(directSmsUrl);

                    //                              // Read raw response body content returned from bulksmsgateway API loop
                    //                              string gatewayReplyLog = await response.Content.ReadAsStringAsync();

                    //                              if (!response.IsSuccessStatusCode)
                    //                              {
                    //                                        Console.WriteLine($"[SMS Gateway Network Error]: HTTP Status -> {response.StatusCode} | Reply -> {gatewayReplyLog}");
                    //                              }
                    //                              else
                    //                              {
                    //                                        // Trace validation status codes sent by the bulk SMS network provider engine itself
                    //                                        Console.WriteLine($"[SMS Gateway Engine Dispatch Log]: {gatewayReplyLog}");
                    //                              }
                    //                    }
                    //                    catch (Exception smsEx)
                    //                    {
                    //                              Console.WriteLine($"[SMS Exception]: Non-blocking thread failure context: {smsEx.Message}");
                    //                    }
                    //          }

                    //          return true;
                    //}
          }
}