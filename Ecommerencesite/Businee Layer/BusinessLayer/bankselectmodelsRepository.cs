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
                    public bankselectmodels DeleteBankSelectModel(int id)
                    {
                           var a=dbContext.bankselectmodelss.Where(s => s.bankselectid == id).FirstOrDefault();
                            if (a != null)
                            {
                                      dbContext.bankselectmodelss.Remove(a);
                                      dbContext.SaveChanges();
                            }
                            return a;



                    }

                    public void AddBankSelectModel(bankselectmodels model)
                    {
                              // 1. Check duplicate
                              var exists = dbContext.bankselectmodelss
                                  .Any(x => x.BankName.ToLower() == model.BankName.ToLower());

                              if (exists)
                              {
                                        // Void return nahi kar sakta, isliye Exception throw karein
                                        throw new Exception("Duplicate Bank Name");
                              }

                              // 2. Save if not duplicate
                              dbContext.bankselectmodelss.Add(model);
                              dbContext.SaveChanges();
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
