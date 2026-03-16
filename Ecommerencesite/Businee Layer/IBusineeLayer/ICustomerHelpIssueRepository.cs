using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ICustomerHelpIssueRepository
          {
                    public ResponseModel AddCustomerHelpIssue(CustomerHelpIssueModel customerHelpIssue);//customer side
                     public ResponseModel GetAllCustomerHelpIssues();//Admin side
          }
}
