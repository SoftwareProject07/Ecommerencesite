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
                              // 1. Validation: Pehle check karein model null toh nahi
                              if (model == null || string.IsNullOrWhiteSpace(model.BankName))
                              {
                                        throw new Exception("Bank Name is required.");
                              }

                              // 2. Strict Duplicate Check:
                              // Trim() se aage peeche ke space khatam honge
                              // ToLower() se Case ka farak khatam hoga
                              var cleanName = model.BankName.Trim().ToLower();

                              var exists = dbContext.bankselectmodelss
                                  .Any(x => x.BankName.Trim().ToLower() == cleanName);

                              if (exists)
                              {
                                        // Yahan se error jayega toh React ke catch block mein dikhega
                                        throw new Exception("Duplicate Bank Name Found!");
                              }

                              // 3. Save as Clean Data
                              model.BankName = model.BankName.Trim().ToUpper(); // Database mein hamesha Capital save karein (Best Practice)
                              dbContext.bankselectmodelss.Add(model);
                              dbContext.SaveChanges();
                    }
                    public List<bankselectmodels> GetAllBankSelectModels()
                    {
                              // Database se data lene ke baad DistinctBy lagayein BankName par
                              var uniqueList = dbContext.bankselectmodelss
                                  .AsEnumerable() // Memory mein lene ke liye taaki string operations ho sakein
                                  .DistinctBy(x => x.BankName.Trim().ToUpper()) // Spaces aur Case sensitive issue khatam karega
                                  .OrderBy(x => x.BankName) // List ko sequence mein rakhega
                                  .ToList();

                              return uniqueList;
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
