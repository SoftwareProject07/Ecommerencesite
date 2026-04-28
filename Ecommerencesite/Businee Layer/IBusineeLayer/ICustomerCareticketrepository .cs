using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ICustomerCareticketrepository
          {
                    //public CustomerCareTicket ProcessNewTicket(CustomerCareTicket ticket);
                    //public List<CustomerCareTicket> GetAllTickets();
                    //public CustomerCareTicket DetailsTicket(int id);
                    //          public CustomerCareTicket UpdateTicketStatus(int id, bool isResolved);
                    //public CustomerCareTicket DeleteCustomerCareTicket(int id);
                    //

                    Task<string> ProcessAiChat(ChatRequest request);
          }
}
