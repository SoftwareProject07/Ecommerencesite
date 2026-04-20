using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class bankselectmodelsAPIController : ControllerBase
          {
                    public readonly IbankselectmodelsRepository _ibankselecttrespository;
                    public bankselectmodelsAPIController(IbankselectmodelsRepository ibankselecttrespository)
                    {
                         this.     _ibankselecttrespository = ibankselecttrespository;
                    }
                    [HttpGet("GetAllBankSelect")]
                    public IActionResult GetAllBankSelectModels()
                    {
                              var bankselectmodels = _ibankselecttrespository.GetAllBankSelectModels().ToList();
                              return Ok(bankselectmodels);
                    }
                    [HttpPost("AddBankSelect")]
                    public void AddBankSelect(bankselectmodels model)
                    {
                              _ibankselecttrespository.AddBankSelectModel(model);

                    }
                    [HttpDelete("DeleteBankSelectModel")]
                    public IActionResult DeleteBankSelectModel(int id)
                    {

                       var a=  _ibankselecttrespository.DeleteBankSelectModel(id);
                              return Ok(a);
                            
                    }
                    [HttpGet("GetBankSelectModelById")]// searching data 
                    public IActionResult GetBankSelectModelById(int id)
                    {
                              var a = _ibankselecttrespository.GetBankSelectModelById(id);
                              return Ok(a);
                    }
                    [HttpPut("UpdateBankSelectModel")]
                    public void UpdateBankSelectModel(bankselectmodels model)
                    {
                              _ibankselecttrespository.UpdateBankSelectModel(model);
                    }
          }
}
