using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model.DASHBOARDS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class TestingDashBoardPanelAPIController : ControllerBase
          {
                    public readonly IDashBoardServicesRepository context;
                    public TestingDashBoardPanelAPIController(IDashBoardServicesRepository _context)
                    {
                              this.context = _context;
                    }
                    [HttpGet("{customerId:int}")]
                    public IActionResult GetCustomerDashboard(int customerId)
                    {
                              var dashboardData = context.GetCustomerDashboard(customerId);

                              if (dashboardData == null || string.IsNullOrEmpty(dashboardData.UserName))
                              {
                                        return NotFound(new { message = $"Customer with ID {customerId} not found." });
                              }

                              return Ok(dashboardData);
                    }



                    //MEDICATION API CONTROLLER CODE        
                    [HttpGet("GetAllMediciation")]
                    public List<Medication> GetAllMediciation()
                    {
                              var medications = context.GetAllAsync();
                              return medications;

                    }

                    [HttpGet("{id}")]
                    public Medication GetByIdAsync(int id)
                    {
                              var med = context.GetByIdAsync(id);

                              return med;
                    }

                    [HttpPost("Create")]
                    public void Create([FromBody] Medication medication)
                    {
                              context.AddAsync(medication);
                    }

                    [HttpPut("{id}")]
                    public void  Update(int id, [FromBody] Medication medication)
                    {
                              context.UpdateAsync( medication);
                    }

                    [HttpDelete("{id}")]
                    public async Task<IActionResult> Delete(int id)
                    {
                               context.DeleteAsync(id);
                              return NoContent();
                    }
          }
}