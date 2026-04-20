using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class BankdetailsRepository : IBankdetailsRepository
          {
                    private readonly Ecommerecewebstedatabase _dbcontext;
                    public BankdetailsRepository(Ecommerecewebstedatabase dbcontext)
                    {
                             this. _dbcontext = dbcontext;       
                    }
                    public void AdminCreatBank(bankdetailsModles bankDetails)
                    {
                          _dbcontext.bankdetailsModless.Add(bankDetails);
                                _dbcontext.SaveChanges();

                    }

                    public bankdetailsModles AdminDeleteBANK(int id)
                    {
                              var bankDetails = _dbcontext.bankdetailsModless.Where(s => s.BankId == id).FirstOrDefault();
                              if (bankDetails != null)
                              {
                                        _dbcontext.bankdetailsModless.Remove(bankDetails);
                                        _dbcontext.SaveChanges();
                              }
                              return bankDetails;

                    }

                    public void AdminupdateBANK(bankdetailsModles bankDetails)
                    {
                          _dbcontext.bankdetailsModless.Update(bankDetails);
                                _dbcontext.SaveChanges();   
                    }

                    public List<bankdetailsModles> GetAllBankDetails()
                    {
                            var listbankDetails = _dbcontext.bankdetailsModless.ToList(); 
                                  return listbankDetails;
                    }
          }
}
