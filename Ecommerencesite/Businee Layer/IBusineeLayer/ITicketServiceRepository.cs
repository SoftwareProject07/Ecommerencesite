using HelpDeskAPI.Models;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ITicketServiceRepository
          {
                    Task<string> RaiseTicket(CustomerTicketRaiseModel model);

                    Task<List<CustomerTicketRaiseModel>> GetAllTickets();

                    Task<CustomerTicketRaiseModel> GetTicketById(int id);

                    Task<List<CustomerTicketRaiseModel>> GetTicketByCustomer(string customerId);

                    Task<List<CustomerTicketRaiseModel>> GetTicketByStatus(string status);

                    Task<List<CustomerTicketRaiseModel>> GetTicketByIssueType(string issueType);

                    //  Task<string> UpdateTicket(CustomerTicketRaiseModel model);
                //    void Updateticket(CustomerTicketRaiseModel model);
                    void Updateticket(int id ,CustomerTicketRaiseModel model);
                    Task<string> DeleteTicket(int id);

                    Task<string> CloseTicket(int ticketId, string remark);
          }
}
