using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using static Twilio.Rest.Intelligence.V3.ConfigurationResource;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class State_CityNameRepository : IState_CityNameRepository
          {
                    public readonly Ecommerecewebstedatabase _context;
                    public  State_CityNameRepository(Ecommerecewebstedatabase context) { 
                    
                              this._context = context;                
                                        
                    }

                    public void AddCityName(CityMasterModel CityName)
                    {
                             _context.cityMasterModels.Add(CityName);
                    }

                    public void AddStateName(StateNameModel StateName)
                    {
                            _context.stateNameModels.Add(StateName);
                    }

                    public List<CityMasterModel> AllCityName()
                    {
                            var istcity = _context.cityMasterModels.ToList();   
                              return istcity;
                    }

                    public List<StateNameModel> AllStateyName()
                    {
                          var liststate = _context.stateNameModels.ToList();
                              return liststate;   
                    }

                    public CityMasterModel DeleteCityName(int Id)
                    {
                              var citydelete = _context.cityMasterModels.FirstOrDefault(x => x.cityid == Id);
                              if (citydelete != null)
                              {
                                        _context.cityMasterModels.Remove(citydelete);
                                        _context.SaveChanges();
                              }
                              return citydelete;
                    }

                    public StateNameModel DeleteStateName(int Id)
                    {
                            var statedelete = _context.stateNameModels.FirstOrDefault(x => x.Id == Id);
                              if (statedelete != null)
                              {
                                        _context.stateNameModels.Remove(statedelete);
                                        _context.SaveChanges();
                              }
                              return statedelete; 
                    }

                    public CityMasterModel GetCityName(int id)
                    {
                            var getcity = _context.cityMasterModels.FirstOrDefault(x => x.cityid == id);
                              return getcity;     
                    }

                    public StateNameModel GetStateName(int id)
                    {
                           var stateget= _context.stateNameModels.FirstOrDefault(x => x.Id == id);
                              return stateget;
                    }

                    public void UpdateCityName(CityMasterModel dto)
                    {
                             _context.cityMasterModels.Update(dto);
                              _context.SaveChanges();
                    }

                    public void UpdateStateName(StateNameModel stateName)
                    {
                             _context.stateNameModels.Update(stateName);
                              _context.SaveChanges();       
                    }
          }
}
