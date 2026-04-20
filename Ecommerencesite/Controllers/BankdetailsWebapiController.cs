using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class BankdetailsWebapiController : ControllerBase
          {
                    private readonly IBankdetailsRepository _bankdetailsRepository;

                    public BankdetailsWebapiController(IBankdetailsRepository bankdetailsRepository)
                    {
                              _bankdetailsRepository = bankdetailsRepository;
                    }
                    [HttpGet("GetAllBankDetails")]
                    public IActionResult GetAllBankDetails()
                    {
                              var bankDetails = _bankdetailsRepository.GetAllBankDetails();
                              return Ok(bankDetails);
                    }
                    [HttpPost("AdminCreatBank")]
                    public void AdminCreatBank(bankdetailsModles bankDetails)
                    {
                              _bankdetailsRepository.AdminCreatBank(bankDetails);
                             
                    }
                    [HttpPut("AdminupdateBANK")]
                    public void AdminupdateBANK(bankdetailsModles bankDetails)
                    {
                              _bankdetailsRepository.AdminupdateBANK(bankDetails);
                    }

                    [HttpDelete("DeleteBankDetails")]
                    public IActionResult AdminDeleteBANK(int id)
                    {
                              var deletedBankDetails = _bankdetailsRepository.AdminDeleteBANK(id);
                            
                              
                              return Ok(deletedBankDetails);
                    }
          }
}