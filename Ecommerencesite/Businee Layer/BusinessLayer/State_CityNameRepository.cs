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
                    public void AddCityName(string CityName)
                    {
                             _context.state_CityNameModels.Add(new State_CityNameModel { CityName = CityName });
                              _context.SaveChanges();
                    }

                    public void AddStateName(string StateName)
                    {
                            _context.state_CityNameModels.Add(new State_CityNameModel { StateName = StateName });
                              _context.SaveChanges();
                    }

                    public List<CityModelDto> AllCityNamedto()
                    {
                             var listcitymodel = _context.state_CityNameModels.Select(x => new CityModelDto
                             {
                                       cityId = x.Id,
                                       CityName = x.CityName
                             }).ToList();   
                              return listcitymodel;         
                    }

                    public List<StateModelDto> AllStateNameDto()
                    {
                            var liststatemodel = _context.state_CityNameModels.Select(x => new StateModelDto
                            {
                                      stateId = x.Id,
                                      StateName = x.StateName
                            }).ToList();    
                              return liststatemodel;
                    }

                    public List<State_CityNameModel> AllState_CityName()
                    {
                              var liststatecitymodel = _context.state_CityNameModels.ToList();
                              return liststatecitymodel;
                    }

                    public State_CityNameModel DeleteCityName(int Id)
                    {
                             var citymodel = _context.state_CityNameModels.FirstOrDefault(x => x.Id == Id);
                              if(citymodel != null)
                              {
                                        _context.state_CityNameModels.Remove(citymodel);
                                        _context.SaveChanges();
                              }
                              return citymodel; 

                    }

                    public State_CityNameModel DeleteStateName(int Id)
                    {
                              var statemodel = _context.state_CityNameModels.FirstOrDefault(x => x.Id == Id);
                              if(statemodel != null)
                              {
                                        _context.state_CityNameModels.Remove(statemodel);
                                        _context.SaveChanges();
                              }
                              return statemodel;
                    }

                    public State_CityNameModel GetCityName(int id)
                    {
                             var citymodel = _context.state_CityNameModels.FirstOrDefault(x => x.Id == id);
                              return citymodel;   
                    }

                    public State_CityNameModel GetStateName(int id)
                    {
                             var statemodel = _context.state_CityNameModels.FirstOrDefault(x => x.Id == id);
                              return statemodel;  
                    }

                    public void UpdateCityName(CityModelDto dto)
                    {
                              var citymodel = _context.state_CityNameModels.FirstOrDefault(x => x.Id == dto.cityId);
                              if (citymodel != null)
                              {
                                        citymodel.Id = dto.cityId;
                                        citymodel.CityName = dto.CityName;
                                        _context.SaveChanges();
                              }

                              _context.state_CityNameModels.Update(citymodel);
                              _context.SaveChanges();
                              //   return  citymodel;   
                    }


                    public void UpdateStateName(StateModelDto stateName)
                    {
                              var statemodel = _context.state_CityNameModels.FirstOrDefault(x => x.Id == stateName.stateId);
                              if (statemodel != null)
                              {
                                        statemodel.Id = stateName.stateId;
                                        statemodel.StateName = stateName.StateName;
                                        _context.SaveChanges();
                              }

                              _context.state_CityNameModels.Update(statemodel);

                    }
          }
}
