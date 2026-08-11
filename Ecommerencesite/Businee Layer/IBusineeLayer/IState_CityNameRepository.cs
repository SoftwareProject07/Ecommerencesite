using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IState_CityNameRepository
          {
                    public List<StateNameModel> AllStateyName();//..statelist
              //      public List<StateNameModel> AllStateNameDto();
                    public List<CityMasterModel> AllCityName();// citylist
                    public void AddCityName(CityMasterModel CityName); //addcity
                    public void AddStateName(StateNameModel StateName);//addstate
                    public void UpdateCityName(CityMasterModel dto);//updatecity
                    public void UpdateStateName(StateNameModel stateName);  //updatestate               
                    public CityMasterModel DeleteCityName(int Id);//deletecity  
                    public StateNameModel DeleteStateName(int Id);//deletestate 
                    public CityMasterModel GetCityName(int id);//getcitybyid
                    public StateNameModel GetStateName(int id);//getstatebyid


          }
}
