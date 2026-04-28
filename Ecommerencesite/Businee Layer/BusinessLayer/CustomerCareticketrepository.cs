using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class CustomerCareticketrepository :ICustomerCareticketrepository
          {
                    public readonly Ecommerecewebstedatabase _dbcontext;
                    public CustomerCareticketrepository(Ecommerecewebstedatabase dbcontext)
                    {
                             this.   _dbcontext = dbcontext;         
                    }

                    public async Task<string> ProcessAiChat(ChatRequest request)
                    {
                              if (string.IsNullOrEmpty(request.Message))
                                        return "I didn't catch that. Could you please repeat?";

                              string userMsg = request.Message.ToLower();

                              // AI Logic / Rules Engine
                              if (userMsg.Contains("order") || userMsg.Contains("track"))
                              {
                                        return "To track your order, please provide your Order ID.";
                              }
                              else if (userMsg.Contains("medicine") || userMsg.Contains("available"))
                              {
                                        return "You can search for medicines using the search bar on our homepage.";
                              }
                              else if (userMsg.Contains("payment") || userMsg.Contains("upi"))
                              {
                                        return "We support UPI, Net Banking, and Credit/Debit cards for secure payments.";
                              }

                              // Default AI Response
                              return "Thank you for reaching out to AKMedizostore support. An agent will be with you shortly if I cannot help!";
                    }






                    //public async Task<string> GetAiResponseAsync(ChatRequest request)
                    //{
                    //          if (string.IsNullOrEmpty(request.Message)) return "How can I help you today?";

                    //          string msg = request.Message.ToLower();

                    //          // Simple AI Logic / Rules
                    //          if (msg.Contains("order")) return "Please provide your Order ID to track your status.";
                    //          if (msg.Contains("payment") || msg.Contains("upi")) return "We accept UPI, Credit Cards, and Net Banking.";
                    //          if (msg.Contains("medicine") || msg.Contains("stock")) return "Most medicines are in stock and ship within 24 hours.";

                    //          return "Thank you for contacting AKMedizostore! An agent will also review this query.";
                    //}
                    //public async Task<string> GetAiResponseAsync(ChatRequest request)
                    //{
                    //          if (string.IsNullOrEmpty(request.Message)) return "How can I help you today?";

                    //          string msg = request.Message.ToLower();

                    //          // Simple AI Logic / Rules
                    //          if (msg.Contains("order")) return "Please provide your Order ID to track your status.";
                    //          if (msg.Contains("payment") || msg.Contains("upi")) return "We accept UPI, Credit Cards, and Net Banking.";
                    //          if (msg.Contains("medicine") || msg.Contains("stock")) return "Most medicines are in stock and ship within 24 hours.";

                    //          return "Thank you for contacting AKMedizostore! An agent will also review this query.";
                    //}
                    //public async Task<string> GetAiResponseAsync(ChatRequest request)
                    //{
                    //          if (string.IsNullOrEmpty(request.Message)) return "How can I help you today?";

                    //          string msg = request.Message.ToLower();

                    //          // Simple AI Logic / Rules
                    //          if (msg.Contains("order")) return "Please provide your Order ID to track your status.";
                    //          if (msg.Contains("payment") || msg.Contains("upi")) return "We accept UPI, Credit Cards, and Net Banking.";
                    //          if (msg.Contains("medicine") || msg.Contains("stock")) return "Most medicines are in stock and ship within 24 hours.";

                    //          return "Thank you for contacting AKMedizostore! An agent will also review this query.";
                    //}
                    //public CustomerCareTicket DeleteCustomerCareTicket(int id)
                    //{
                    //          var a = _dbcontext.CustomerCareTickets.Where(s => s.Id == id).FirstOrDefault();
                    //                  _dbcontext.CustomerCareTickets.Remove(a); 
                    //           _dbcontext.SaveChanges();
                    //           return a;
                    //}

                    //public CustomerCareTicket DetailsTicket(int id)
                    //{
                    //          var detailsticket= _dbcontext.CustomerCareTickets.Where(s => s.Id == id).FirstOrDefault();     
                    //          return detailsticket;         
                    //}

                    //public List<CustomerCareTicket> GetAllTickets()
                    //{
                    //          throw new NotImplementedException();
                    //}

                    //public CustomerCareTicket GetTicket(int id)
                    //{
                    //          throw new NotImplementedException();
                    //}

                    //public CustomerCareTicket ProcessNewTicket(CustomerCareTicket ticket)
                    //{
                    //          throw new NotImplementedException();
                    //}

                    //public CustomerCareTicket UpdateTicketStatus(int id, bool isResolved)
                    //{
                    //          throw new NotImplementedException();
                    //}
          }
}
