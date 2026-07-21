using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class BankRefundableAmountAPIController : ControllerBase
          {
                    public readonly IBankRefundableAmountRepository _bankRefundableAmountRepository;
                    public BankRefundableAmountAPIController(IBankRefundableAmountRepository bankRefundableAmountRepository)
                    {
                         this.     _bankRefundableAmountRepository = bankRefundableAmountRepository;
                    }
                    [HttpPost("AddBankRefundableAmount")]
                    public void AddBankRefundableAmount(BankRefundableAmountModel bankRefundableAmount)
                    {
                              _bankRefundableAmountRepository.AddBankRefundableAmount(bankRefundableAmount);
                    }
                    [HttpDelete("DeleteBankRefundableAmount/{id}")]
                    public BankRefundableAmountModel DeleteBankRefundableAmount(int id)
                    {
                              return _bankRefundableAmountRepository.DeleteBankRefundableAmount(id);
                    }
                    [HttpGet("DetailsBankRefundableAmount")]
                    public BankRefundableAmountModel DetailsBankRefundableAmount(int id)
                    {
                              return _bankRefundableAmountRepository.DetailsBankRefundableAmount(id);         
                    }
                    [HttpGet("GetAllBankRefundableAmounts")]
                    public List<BankRefundableAmountModel> GetAllBankRefundableAmounts()
                    {
                              var listrefundable= _bankRefundableAmountRepository.GetAllBankRefundableAmounts().ToList();
                              return listrefundable;        
                    }
                    [HttpPut("UpdateBankRefundableAmount")]
                    public void UpdateBankRefundableAmount(BankRefundableAmountModel updatebankrefundable)
                    {
                              _bankRefundableAmountRepository.UpdateBankRefundableAmount(updatebankrefundable);
                    }
          }
}
