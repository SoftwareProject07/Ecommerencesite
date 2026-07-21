using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IBankRefundableAmountRepository
          {
                    public List<BankRefundableAmountModel> GetAllBankRefundableAmounts();

                    public void AddBankRefundableAmount(BankRefundableAmountModel bankRefundableAmount);
                    public void UpdateBankRefundableAmount(BankRefundableAmountModel updatebankrefundable);
                    public BankRefundableAmountModel DeleteBankRefundableAmount(int id);
                    public BankRefundableAmountModel DetailsBankRefundableAmount(int id);
          }
}
