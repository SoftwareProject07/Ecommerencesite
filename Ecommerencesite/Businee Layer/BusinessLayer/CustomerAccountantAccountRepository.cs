

using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class CustomerAccountantAccountRepository : ICustomerAccountantAccountRepository
          {
                    public readonly Ecommerecewebstedatabase _dbcontext;
                    public CustomerAccountantAccountRepository(Ecommerecewebstedatabase dbcontex)
                    {
                         this .  _dbcontext= dbcontex;
                    }

                    public List<CustomerAccountantAccount> AllCustomerAccounts() { 
                             var listofcustomerAccount = _dbcontext.customerAccountantAccounts.ToList();
                              return listofcustomerAccount;
                    }                             

                    public void CreateCustomerAccount(CustomerAccountantAccount addcustomerAccount)
                    {
                              _dbcontext.customerAccountantAccounts.Add(addcustomerAccount);
                              _dbcontext.SaveChanges();
                    }

                    public CustomerAccountantAccount DeleteCustomerAccount(int id)

                    { 
                              var deletecustomerAccount = _dbcontext.customerAccountantAccounts.Find(id);
                              if (deletecustomerAccount != null)
                              {
                                        _dbcontext.customerAccountantAccounts.Remove(deletecustomerAccount);
                                        _dbcontext.SaveChanges();
                              }
                              return deletecustomerAccount;
                    }

                    public  CustomerAccountantAccount GetCustomerAccountById(int id)
                    {
                            
                              var getcustomerAccount = _dbcontext.customerAccountantAccounts.Find(id);
                              return getcustomerAccount;    
                    }

                    public void UpdateCustomerAccount(CustomerAccountantAccount updatecustomerAccount)

                    {

                              _dbcontext.customerAccountantAccounts.Update(updatecustomerAccount);
                              _dbcontext.SaveChanges();     
                    }

          }
}