using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using static Twilio.Rest.Intelligence.V3.ConfigurationResource;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class TrackingHub : Hub
          {

                
                  
                    public  async Task JoinOrderGroup(string orderId)
                    {
                              await Groups.AddToGroupAsync(Context.ConnectionId, orderId);
                    }

                    public Task LeaveOrderGroup(string orderId)
                    {
                              throw new NotImplementedException();
                    }
          }
}
