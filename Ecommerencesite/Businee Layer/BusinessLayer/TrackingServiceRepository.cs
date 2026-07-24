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

                    public void AddOrder(Order addorder)
                    {
                           _context.orderss.Add(addorder);
                              _context.SaveChanges();

                    }

                    public void AddOrderItem(OrderItem ordersitem)
                    {
                            _context.orderItemss.Add(ordersitem);
                              _context.SaveChanges();
                    }

                    public List<OrderItem> AllOrderItem()
                    {
                           var listorderitem = _context.orderItemss.ToList();
                              return listorderitem;
                    }

                    //public List<OrderItem> AllOrderItems(int OrderId)
                    //{
                    //          //try
                    //          //{
                    //          //          // Fetch all records for the specified orderId
                    //          //          var a = _context.orderItemss.Where(OrderId);
                    //          //          return a;
                    //          //}
                    //          //catch (Exception ex)
                    //          //{
                    //          //          // Log exception here if necessary
                    //          //          throw new Exception("Error retrieving order items: " + ex.Message);
                    //          //}
                    //          var orderItems = _context.orderItemss.Where(oi => oi.OrderId == OrderId).ToList();
                    //                    return orderItems;
                    //}

                    public List<OrderItem> AllOrderItems(int OrderId)
                    {
                              try
                              {
                                        // Using the exact context name provided and a correct LINQ lambda expression with .ToList()
                                        var orderItems = _context.orderItemss
                                                                 .Where(oi => oi.OrderId == OrderId)
                                                                 .ToList();

                                        return orderItems;
                              }
                              catch (Exception ex)
                              {
                                        // Log exception here if necessary
                                        throw new Exception("Error retrieving order items: " + ex.Message);
                              }
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