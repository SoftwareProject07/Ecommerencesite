
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ICustomerAccountantAccountRepository
          {
                    //Task<IEnumerable<CustomerAccount>> GetAllCustomersAsync();
                    //Task<CustomerAccount> GetCustomerByIdAsync(int id);
                    //Task<CustomerAccount> CreateCustomerAsync(CustomerAccount customer);
                    //Task UpdateCustomerAsync(CustomerAccount customer);
                    //Task DeleteCustomerAsync(int id);

                    public List<CustomerAccountantAccount> AllCustomerAccounts();
                    public CustomerAccountantAccount GetCustomerAccountById(int id);
                    public void CreateCustomerAccount(CustomerAccountantAccount addcustomerAccount);   
                    public void UpdateCustomerAccount(CustomerAccountantAccount updatecustomerAccount);
                    public  CustomerAccountantAccount DeleteCustomerAccount(int id);



          }
}
