using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Owin.BuilderProperties;
using System;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class TrackingServiceRepository : IITrackingServiceRepository
          {
                    private readonly Ecommerecewebstedatabase _context;
                    private readonly IHubContext<TrackingHub> _hubContext;

                    public TrackingServiceRepository(Ecommerecewebstedatabase context, IHubContext<TrackingHub> hubContext)
                    {
                              _context = context;
                              _hubContext = hubContext;
                    }

                    //public void AddAddress(deliverypartnermodel adddeliverpartner)
                    //{
                    //          _context.deliverypartnermodels.Add(adddeliverpartner);
                    //          _context.SaveChanges();
                    //}

                   
                    public async Task<bool> UpdateDeliveryLocationAsync(int orderId, decimal latitude, decimal longitude)
                    {
                              var order = await _context.orderss.FindAsync(orderId);
                              if (order == null) return false;

                              // SignalR ke through specific order group ko live coordinates broadcast karein
                              await _hubContext.Clients.Group(orderId.ToString())
                                  .SendAsync("ReceiveLiveLocation", latitude, longitude);

                              return true;
                    }

          }

}