using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class CustomerAccountantAccountAPIController : ControllerBase
          {
                    public readonly ICustomerAccountantAccountRepository _customerAccountantAccountRepository;
                    public CustomerAccountantAccountAPIController(ICustomerAccountantAccountRepository    customerAccountantAccountRepository)
                    {
                           this. _customerAccountantAccountRepository = customerAccountantAccountRepository;  
                    }


                    [HttpGet("AllCustomerAccounts")]
                    public List<CustomerAccountantAccount> AllCustomerAccounts()
                    {
                              return _customerAccountantAccountRepository.AllCustomerAccounts();
                    }

                    [HttpGet("DetailsCustomerAccount")]
                    public CustomerAccountantAccount GetCustomerAccountById(int id)
                    {
                              return _customerAccountantAccountRepository.GetCustomerAccountById(id);
                    }
                    [HttpPost("CreateCustomerAccount")]
                    public void CreateCustomerAccount(CustomerAccountantAccount addcustomerAccount)
                    {
                              _customerAccountantAccountRepository.CreateCustomerAccount(addcustomerAccount);
                    }
                    [HttpPut("UpdateCustomerAccount")]
                    public void UpdateCustomerAccount(CustomerAccountantAccount updatecustomerAccount)
                    {
                              _customerAccountantAccountRepository.UpdateCustomerAccount(updatecustomerAccount);
                    }
                    [HttpDelete("DeleteCustomerAccount")]
                    public CustomerAccountantAccount DeleteCustomerAccount(int id)
                    {
                              return _customerAccountantAccountRepository.DeleteCustomerAccount(id);
                    }

          }
}
