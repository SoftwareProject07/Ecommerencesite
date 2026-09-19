using Ecommerencesite.Businee_Layer.IBusineeLayer.LABTESTIBUSINESSLAYER;
using LabTestApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers.LABTESTCONTROLLER
{
          [Route("api/[controller]")]
          [ApiController]
          public class OfferTestAPIController : ControllerBase
          {
                    public readonly IOfferTestBusiness _offerTestBusiness;
                    public OfferTestAPIController(IOfferTestBusiness _offerTestBusiness)
                    {
                              this._offerTestBusiness = _offerTestBusiness;

                    }
                    [HttpGet("AllOfferTestModel")]
                    public async Task<List<OfferTestModel>> GetAllOffersAsync()
                    {
                              var offers = await _offerTestBusiness.GetAllOffersAsync();
                              return offers;
                    }

                    [HttpGet("DetailsOfferTestModel")]
                    public async Task<OfferTestModel> GetOfferByIdAsync(int id)
                    {
                              var offer = await _offerTestBusiness.GetOfferByIdAsync(id);
                              return offer;
                    }

                    [HttpGet("SearchOfferTestModel")]
                    public async Task<List<OfferTestModel>> SearchOffersAsync(string keyword)
                    {
                              var offers = await _offerTestBusiness.SearchOffersAsync(keyword);
                              return offers;
                    }

                    [HttpPost("CreateOfferTestModel")]
                    public async Task<IActionResult> CreateOfferAsync([FromBody] OfferTestModel model)
                    {
                              var result = await _offerTestBusiness.CreateOfferAsync(model);
                              if (result)
                              {
                                        return Ok(new { message = "Offer created successfully." });
                              }
                              else
                              {
                                        return BadRequest(new { message = "Failed to create offer." });
                              }
                    }

                    [HttpPut("UpdateOfferTestModel")]
                    public async Task<IActionResult> UpdateOfferAsync([FromBody] OfferTestModel model)
                    {
                              var result = await _offerTestBusiness.UpdateOfferAsync(model);
                              if (result)
                              {
                                        return Ok(new { message = "Offer updated successfully." });
                              }
                              else
                              {
                                        return BadRequest(new { message = "Failed to update offer." });
                              }
                    }

                    [HttpDelete("DeleteOfferTestModel")]
                    public async Task<IActionResult> DeleteOfferAsync(int id)
                    {
                              var result = await _offerTestBusiness.DeleteOfferAsync(id);
                              if (result)
                              {
                                        return Ok(new { message = "Offer deleted successfully." });
                              }
                              else
                              {
                                        return BadRequest(new { message = "Failed to delete offer." });
                              }
                    }



          }
}
