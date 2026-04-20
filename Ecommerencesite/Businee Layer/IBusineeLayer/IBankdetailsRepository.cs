using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IBankdetailsRepository
          {
                    public List<bankdetailsModles> GetAllBankDetails();
                    public void AdminCreatBank(bankdetailsModles bankDetails);
                    public void  AdminupdateBANK(bankdetailsModles bankDetails);
                    public bankdetailsModles AdminDeleteBANK(int id);

          }
}
