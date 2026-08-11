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
                    public void AddCityName(string CityName)
                    {
                              _state_CityNameRepository.AddCityName(CityName);

                    }
                    [HttpPost("AddStateName")]
                    public void AddStateName(string StateName)
                    {
                              _state_CityNameRepository.AddStateName(StateName);
                    }
                    [HttpGet("AllCityNamedto")]
                    public List<CityModelDto> AllCityNamedto()
                    {
                              return _state_CityNameRepository.AllCityNamedto();
                    }
                    [HttpGet("AllStateNameDto")]
                    public List<StateModelDto> AllStateNameDto()
                    {
                              return _state_CityNameRepository.AllStateNameDto();
                    }
                    [HttpGet("AllState_CityName")]
                    public List<State_CityNameModel> AllState_CityName()
                    {
                              return _state_CityNameRepository.AllState_CityName();
                    }
                    [HttpDelete("DeleteCityName")]
                    public State_CityNameModel DeleteCityName(int Id)
                    {
                              return _state_CityNameRepository.DeleteCityName(Id);
                    }
                    [HttpDelete("DeleteStateName")]
                    public State_CityNameModel DeleteStateName(int Id)
                    {
                              return _state_CityNameRepository.DeleteStateName(Id);
                    }
                    [HttpGet("DetailsCityName")]
                    public State_CityNameModel GetCityName(int id)
                    {
                              return _state_CityNameRepository.GetCityName(id);
                    }
                    [HttpGet("DetailsStateName")]

                    public State_CityNameModel GetStateName(int id)
                    {
                              return _state_CityNameRepository.GetStateName(id);
                    }
                    [HttpPut("UpdateCityName")]

                    public void UpdateCityName(CityModelDto dto)
                    {
                              _state_CityNameRepository.UpdateCityName(dto);
                    }
                    [HttpPut("UpdateStateName")]
                    public void UpdateStateName(StateModelDto stateName)
                    {
                              _state_CityNameRepository.UpdateStateName(stateName);
                    }





          }
}

