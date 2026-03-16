using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class CustomerHelpIssueRepository: ICustomerHelpIssueRepository
          {
                    public readonly Ecommerecewebstedatabase _dbContext;
                    public CustomerHelpIssueRepository(Ecommerecewebstedatabase dbContext)
                    {
                              this._dbContext = dbContext;
                    }
                    public ResponseModel AddCustomerHelpIssue(CustomerHelpIssueModel customerHelpIssue)
                     {
                             var response = new ResponseModel();
                                try
                                {
                                          _dbContext.customerHelpIssueModels.Add(customerHelpIssue);  
                                          _dbContext.SaveChanges();
                                          response.status = true;
                                          response.responseMessage = "Customer help issue added successfully.";
                                }
                                catch (Exception ex)
                                {
                                          response.status = false;
                                          response.responseMessage = $"Error adding customer help issue: {ex.Message}";
                                }
                                return response;
                     }
                     public ResponseModel GetAllCustomerHelpIssues()
                     {
                              var response = new ResponseModel();
                                try
                                {
                                          var customerHelpIssues = _dbContext.customerHelpIssueModels.ToList();
                                          response.status = true;
                                          response.responseMessage = "Customer help issues retrieved successfully.";
                                          response.Data = customerHelpIssues;
                                }
                                catch (Exception ex)
                                {
                                          response.status = false;
                                          response.responseMessage = $"Error retrieving customer help issues: {ex.Message}";
                                }
                                return response;
                    }         
          }
}
