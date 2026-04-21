using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class bankselectmodelsRepository : IbankselectmodelsRepository
          {
                    public readonly Ecommerecewebstedatabase dbContext;
                    public bankselectmodelsRepository(Ecommerecewebstedatabase _dbcontext )
                    {
                               this.dbContext= _dbcontext; 
                    }
                    public void AddBankSelectModel(bankselectmodels model)
                    {
                              dbContext.bankselectmodelss.Add(model);
                              dbContext.SaveChanges();

                    }

                    public bankselectmodels DeleteBankSelectModel(int id)
                    {
                              var model = dbContext.bankselectmodelss.Where(s => s.bankselectid == id).FirstOrDefault();
                              if (model != null)
                              {
                                        dbContext.bankselectmodelss.Remove(model);
                                        dbContext.SaveChanges();
                              }
                              return   model;
                    }

                    public List<bankselectmodels> GetAllBankSelectModels()
                    {
                             var listbankselectmodels = dbContext.bankselectmodelss.ToList();
                              return listbankselectmodels;  

                    }

                    public bankselectmodels GetBankSelectModelById(int id)
                    {
                              var model = dbContext.bankselectmodelss.Where(s => s.bankselectid == id).FirstOrDefault();
                              return model;
                    }

                    public void UpdateBankSelectModel(bankselectmodels model)
                    {
                            dbContext.bankselectmodelss.Update(model);
                              dbContext.SaveChanges();
                    }
          }
}
