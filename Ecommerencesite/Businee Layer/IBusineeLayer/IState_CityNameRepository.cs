using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IState_CityNameRepository
          {
                    public List<State_CityNameModel> AllState_CityName();
                    public List<StateModelDto> AllStateNameDto();
                    public List<CityModelDto> AllCityNamedto();
                    public void AddCityName(string CityName);
                    public void AddStateName(string StateName);
                    public void UpdateCityName(CityModelDto dto);
                    public void UpdateStateName(StateModelDto stateName);                
                    public State_CityNameModel DeleteCityName(int Id);
                    public State_CityNameModel DeleteStateName(int Id);
                    public State_CityNameModel GetCityName(int id);
                    public State_CityNameModel GetStateName(int id);


          }
}
