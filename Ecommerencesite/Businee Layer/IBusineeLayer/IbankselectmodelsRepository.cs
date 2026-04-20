using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public interface IbankselectmodelsRepository
          {
                  public List<bankselectmodels> GetAllBankSelectModels();
                   public bankselectmodels GetBankSelectModelById(int id);
                   public void AddBankSelectModel(bankselectmodels model);
                   public void UpdateBankSelectModel(bankselectmodels model);
                   public bankselectmodels DeleteBankSelectModel(int id);
          }
}
