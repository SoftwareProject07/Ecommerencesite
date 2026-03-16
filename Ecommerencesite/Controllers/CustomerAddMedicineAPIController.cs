using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class CustomerAddMedicineAPIController : ControllerBase
          {
                    private readonly ICustomerAddMedicineRepositorycs _customerAddMedicineRepository;
                    public CustomerAddMedicineAPIController(ICustomerAddMedicineRepositorycs customerAddMedicineRepository)
                    {
                              this._customerAddMedicineRepository = customerAddMedicineRepository;
                    }
                    [HttpPost("AddCustomerAddedMedicine")]
                    public IActionResult AddCustomerAddedMedicine(CustomerAddMedicineModel customerAddMedicine)
                    {
                              try
                              {
                                        var response = _customerAddMedicineRepository.AddCustomerAddMedicine(customerAddMedicine);
                                        if (response.status)
                                        {
                                                  return Ok(response.responseMessage);
                                        }
                                        else
                                        {
                                                  return BadRequest(response.responseMessage);
                                        }
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }
                    [HttpGet("GetAllCustomerAddedMedicines")]
                    public IActionResult GetAllCustomerAddedMedicines()
                    {
                              try
                              {
                                        var response = _customerAddMedicineRepository.GetAllCustomerAddMedicines();
                                        if (response.status)
                                        {
                                                  return Ok(response.Data);
                                        }
                                        else
                                        {
                                                  return BadRequest(response.responseMessage);
                                        }
                              }
                              catch (Exception ex)
                              {
                                        return StatusCode(500, $"Internal server error: {ex.Message}");
                              }
                    }
          }
}
