using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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

                    public List<Order> GetAllOrdersAsync()
                    {
                              var listorder = _context.orderss.ToList();
                              return listorder;
                                  //.Include(o => o.Address)
                                  //.Include(o => o.OrderItems)
                                  //.OrderByDescending(o => o.CreatedAt)
                                  //.ToList();
                    }

                    // public async Task<List<Order>> GetAllOrdersAsync() { 
                    //{
                    //          return await _context.orderss
                    //              .Include(o => o.Address)
                    //              .Include(o => o.OrderItems)
                    //              .OrderByDescending(o => o.CreatedAt)
                    //              .ToListAsync();
                    //  }

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