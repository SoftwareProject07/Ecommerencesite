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
                              // GroupBy use karke hum har BankName ka pehla record uthayenge
                              var listbankselectmodels = dbContext.bankselectmodelss
                                  .AsEnumerable() // Memory mein laane ke liye (Case-insensitive handle karne ke liye)
                                  .GroupBy(x => x.BankName.Trim().ToLower()) // Name ke hisaab se group banayein
                                  .Select(g => g.First()) // Har group ka pehla element lein
                                  .ToList();

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
