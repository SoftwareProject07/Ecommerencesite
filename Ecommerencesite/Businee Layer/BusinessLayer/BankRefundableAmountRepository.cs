using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class BankRefundableAmountRepository : IBankRefundableAmountRepository
          {
                    public readonly Ecommerecewebstedatabase _dbContext;
                    public BankRefundableAmountRepository(Ecommerecewebstedatabase dbContext)
                    {
                             this. _dbContext = dbContext;       
                    }
                    public void AddBankRefundableAmount(BankRefundableAmountModel bankRefundableAmount)
                    {
                           _dbContext.BankRefundableAmountModels.Add(bankRefundableAmount);
                                    _dbContext.SaveChanges();
                    }

                    public BankRefundableAmountModel DeleteBankRefundableAmount(int id)
                    {
                              var deletebankRefundableAmount = _dbContext.BankRefundableAmountModels.Where(s => s.BankRefundableAmountid == id).FirstOrDefault();

                              _dbContext.BankRefundableAmountModels.Remove(deletebankRefundableAmount);
                              _dbContext.SaveChanges();
                              return deletebankRefundableAmount;
                    }

                              

                    public BankRefundableAmountModel DetailsBankRefundableAmount(int id)
                    {
                             var detailsbankRefundableAmount = _dbContext.BankRefundableAmountModels.Where(s => s.BankRefundableAmountid == id).FirstOrDefault();
                              return detailsbankRefundableAmount;     
                    }

                    public List<BankRefundableAmountModel> GetAllBankRefundableAmounts()
                    {
                             var listbankRefundableAmount = _dbContext.BankRefundableAmountModels.ToList();
                              return listbankRefundableAmount;        

                    }

                    public void UpdateBankRefundableAmount(BankRefundableAmountModel updatebankrefundable)
                    {
                            _dbContext.BankRefundableAmountModels.Update(updatebankrefundable);
                                  _dbContext.SaveChanges();
                    }
          }
}
