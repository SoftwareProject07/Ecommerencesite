using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Controllers
{
          [Route("api/[controller]")]
          [ApiController]
          public class State_CityModelAPIController : ControllerBase
          {
                    public readonly IState_CityNameRepository _state_CityNameRepository;
                    public State_CityModelAPIController(IState_CityNameRepository state_CityNameRepository)
                    {
                              this._state_CityNameRepository = state_CityNameRepository;
                    }
                    [HttpPost("AddCityName")]
                    public void AddCityName(CityMasterModel CityName)
                    {
                              _state_CityNameRepository.AddCityName(CityName);

                    }
                    [HttpPost("AddStateName")]
                    public void AddStateName(StateNameModel StateName)
                    {
                              _state_CityNameRepository.AddStateName(StateName);
                    }
                    [HttpGet("AllCityNamedto")]
                    public List<CityMasterModel> AllCityName()
                    {
                              return _state_CityNameRepository.AllCityName().ToList();
                    }
                    [HttpGet("AllStateNameDto")]
                    public List<StateNameModel> AllStateyName()
                    {
                              return _state_CityNameRepository.AllStateyName().ToList();
                    }
                    //[HttpGet("AllState_CityName")]
                    //public List<State_CityNameModel> AllState_CityName()
                    //{
                    //          return _state_CityNameRepository.AllState_CityName();
                    //}
                    [HttpDelete("DeleteCityName")]
                    public CityMasterModel DeleteCityName(int Id)
                    {
                              return _state_CityNameRepository.DeleteCityName(Id);
                    }
                    [HttpDelete("DeleteStateName")]
                    public StateNameModel DeleteStateName(int Id)
                    {
                              return _state_CityNameRepository.DeleteStateName(Id);
                    }
                    [HttpGet("DetailsCityName")]
                    public StateNameModel GetStateName(int id)
                    {
                              return _state_CityNameRepository.GetStateName(id);
                    }
                    [HttpGet("DetailsStateName")]

                    public CityMasterModel GetCityName(int id)
                    {
                              return _state_CityNameRepository.GetCityName(id);
                    }
                    [HttpPut("UpdateCityName")]

                    public void UpdateCityName(CityMasterModel dto)
                    {
                              _state_CityNameRepository.UpdateCityName(dto);
                    }
                    [HttpPut("UpdateStateName")]
                    public void UpdateStateName(StateNameModel stateName)
                    {
                              _state_CityNameRepository.UpdateStateName(stateName);
                    }





          }
}

