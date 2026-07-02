using Microsoft.EntityFrameworkCore;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using HelpDeskAPI.Models;

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
                    public async Task<string> RaiseTicket(CustomerTicketRaiseModel model)
                    {
                              model.CreatedDate = DateTime.UtcNow;
                              model.Status = "Open";
                              model.TicketNumber = "TKT" + DateTime.Now.ToString("yyyyMMddHHmmss");

                              await _context.CustomerTicketRaise.AddAsync(model);
                              await _context.SaveChangesAsync();

                              return $"Ticket Raised Successfully. Ticket No : {model.TicketNumber}";
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
                    public async Task<string> UpdateTicket(CustomerTicketRaiseModel model)
                    {
                              var ticket = await _context.CustomerTicketRaise
                                  .FirstOrDefaultAsync(x => x.TicketId == model.TicketId);

                              if (ticket == null)
                                        return "Ticket Not Found";

                              ticket.CustomerName = model.CustomerName;
                              ticket.CustomerId = model.CustomerId;
                              ticket.MobileNo = model.MobileNo;
                              ticket.Email = model.Email;
                              ticket.OrderId = model.OrderId;
                              ticket.MedicineName = model.MedicineName;
                              ticket.IssueCategory = model.IssueCategory;
                              ticket.Subject = model.Subject;
                              ticket.Description = model.Description;
                              ticket.Priority = model.Priority;
                              ticket.Status = model.Status;
                              ticket.Attachment = model.Attachment;
                              ticket.AssignedTo = model.AssignedTo;
                              ticket.ResolutionRemark = model.ResolutionRemark;
                              ticket.UpdatedDate = DateTime.Now;

                              await _context.SaveChangesAsync();

                              return "Ticket Updated Successfully";
                    }

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
          }
}