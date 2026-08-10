using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class LanguageAPIController : ControllerBase
          {
                    private readonly ILanguageService _languageService;

                    public LanguageAPIController(ILanguageService languageService)
                    {
                              _languageService = languageService;
                    }

                    // GET: api/LanguageAPI
                    [HttpGet("AllCurrentLanguageAsync")]
                    //public async Task<IActionResult> AllCurrentLanguageAsync()
                    //{
                    //          try
                    //          {
                    //                    var lang = await _languageService.AllCurrentLanguageAsync();
                    //                    return Ok(new { success = true, preferred_language = lang });
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ex.Message });
                    //          }
                    //}


                    public List<choice_MultipleLanguageModel> AllCurrentLanguageAsync()
                    {
                              try
                              {
                                        var lang = _languageService.AllCurrentLanguageAsync();
                                        return lang;
                              }
                              catch (Exception ex)
                              {
                                        // Handle the exception as needed, e.g., log it
                                        throw new Exception("An error occurred while retrieving languages.", ex);
                              }
                    }

                    // POST: api/LanguageAPI
                    [HttpPut("UpdateLanguage")]
                    //public async Task<IActionResult> UpdateLanguage([FromBody] choice_MultipleLanguageModel model)
                    //{
                    //          try
                    //          {
                    //                    if (model == null || string.IsNullOrWhiteSpace(model.PreferredLanguage))
                    //                    {
                    //                              return BadRequest(new { success = false, message = "Invalid language payload." });
                    //                    }

                    //                    var updated = await _languageService.UpdateLanguageAsync(model);
                    //                    return Ok(new { success = true, message = "Language updated successfully", data = updated });
                    //          }
                    //          catch (ArgumentException ex)
                    //          {
                    //                    return BadRequest(new { success = false, message = ex.Message });
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = ex.Message });
                    //          }
                    //}
                    public void UpdateLanguageAsync(choice_MultipleLanguageModel model)
                    {
                              try
                              {
                                        if (model == null || string.IsNullOrWhiteSpace(model.PreferredLanguage))
                                        {
                                                  throw new ArgumentException("Invalid language payload.");
                                        }
                                        _languageService.UpdateLanguageAsync(model);
                              }
                              catch (ArgumentException ex)
                              {
                                        throw new ArgumentException(ex.Message);
                              }
                              catch (Exception ex)
                              {
                                        throw new Exception("An error occurred while updating the language.", ex);
                              }         
                    }
                    [HttpPost("CreateLanguage")]

                    public void CreateLanguage(choice_MultipleLanguageModel createmodel)
                    {
                              _languageService.CreateLanguage(createmodel);
                              
                    }

                    [HttpGet("DetailsLanguage")]

                    public choice_MultipleLanguageModel DetailsLanguage(int id)
                    {
                              return _languageService.DetailsLanguage(id);      
                    }

                    [HttpDelete("DeleteLanguage")]
                    public choice_MultipleLanguageModel DeleteLanguage(int id)
                    {
                              return _languageService.DeleteLanguage(id);
                    }
          }
}