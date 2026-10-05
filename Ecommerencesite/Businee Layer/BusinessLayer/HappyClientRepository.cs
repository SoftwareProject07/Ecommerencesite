using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model.HAPPYCLIENT;
using Microsoft.EntityFrameworkCore;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class HappyClientRepository : IHappyClientRepository
          {
                    public readonly Ecommerecewebstedatabase _context;
                    public HappyClientRepository(Ecommerecewebstedatabase context)
                    {
                              this._context = context;

                    }

                    public void AddClientAsync(HappyClient client)
                    {
                            _context.HappyClients.Add(client);
                                  _context.SaveChanges();
                    }

                    public List<HappyClient> AllClientsAsync()
                    {
                            var listhappyyclients = _context.HappyClients.ToList();       
                              return listhappyyclients;
                    }

                    public HappyClient DeleteClientAsync(int id)
                    {
                            var deletehapppyclinent= _context.HappyClients.Where(s=>s.Id == id).FirstOrDefault();
                              if(deletehapppyclinent != null)
                              {
                                        _context.HappyClients.Remove(deletehapppyclinent);
                                        _context.SaveChanges();
                              }
                              return deletehapppyclinent;   
                    }

                    public HappyClient DetailsHappyClient(int id)
                    {
                            var detailshappyclient = _context.HappyClients.Where(s => s.Id == id).FirstOrDefault();
                              return detailshappyclient;
                    }

                    public void UpdateClientAsync(HappyClient client)
                    {
                              _context.HappyClients.Update(client);
                              _context.SaveChanges();
                    }
                    //  public void  AddClientAsync(HappyClient client)
                    //  {
                    //                      client.CreatedAt = DateTime.UtcNow;
                    //                      _context.HappyClients.Add(client);
                    //                      _context.SaveChanges();
                    //                      //return client;    
                    //  }

                    //  public async  Task<bool> DeleteClientAsync(int id)
                    //  {
                    //            var client = await _context.HappyClients.FindAsync(id);
                    //            if (client == null) return false;

                    //            _context.HappyClients.Remove(client);
                    //            await _context.SaveChangesAsync();
                    //            return true;
                    //  }

                    //  public  async Task<IEnumerable<HappyClient>> GetAllClientsAsync()
                    //  {
                    //            return await _context.HappyClients
                    //.OrderByDescending(c => c.CreatedAt)
                    //.ToListAsync();
                    //  }

                    //  public  async  Task<HappyClient?> GetClientByIdAsync(int id)
                    //  {
                    //            return await _context.HappyClients.FindAsync(id);
                    //  }

                    //  public void  UpdateClientAsync( HappyClient client)
                    //  {
                    //            _context.HappyClients.Update(client);
                    //            _context.SaveChanges();
                    //            //var existingClient = await _context.HappyClients.FindAsync(id);
                    //            //if (existingClient == null) return false;

                    //            //existingClient.ClientName = client.ClientName;
                    //            //existingClient.Designation = client.Designation;
                    //            //existingClient.Company = client.Company;
                    //            //existingClient.TestimonialText = client.TestimonialText;
                    //            //existingClient.Rating = client.Rating;
                    //            //existingClient.ImageUrl = client.ImageUrl;
                    //            //existingClient.IsActive = client.IsActive;


                    //  }


          }
}
