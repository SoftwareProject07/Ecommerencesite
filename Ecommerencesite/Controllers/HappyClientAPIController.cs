using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model.HAPPYCLIENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class HappyClientAPIController : ControllerBase
          {
                    public readonly IHappyClientRepository _happyClientRepository;
                    public HappyClientAPIController(IHappyClientRepository    happyClientRepository)
                    {
                          this.  _happyClientRepository = happyClientRepository;   
                    }



                    // GET: api/happyclients
                    [HttpGet("AllHappyClient")]
                    public List<HappyClient> AllClientsAsync()
                    {
                              var clients = _happyClientRepository.AllClientsAsync();
                              return clients;
                    }
                    // GET: api/happyclients/5
                                [HttpGet("DetailsHappyClient")]
                              public HappyClient DetailsHappyClient(int id)
                              {
                                var detailshapplicant = _happyClientRepository.DetailsHappyClient(id);



                              return detailshapplicant;
                    }


                    // POST: api/happyclients
                    [HttpPost("CreateHappyClient")]
                    public void  Create(HappyClient client)
                    {
                          _happyClientRepository.AddClientAsync(client);        
                    }


                    // PUT: api/happyclients/5
                    [HttpPut("UpdateHappyClient")]
                    public void UpdateClientAsync(HappyClient client)
                    {
                              //if (!ModelState.IsValid)
                              //{
                              //          return BadRequest(ModelState);
                              //}

                              _happyClientRepository.UpdateClientAsync(client);

                    }


                    // DELETE: api/happyclients/5
                    [HttpDelete("DeleteHappyClient")]
                    public HappyClient DeleteClientAsync(int id)
                    {
                            
                              var deletedClient = _happyClientRepository.DeleteClientAsync(id);
                              return deletedClient;
                    }
          }
}
