using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class CustomerAddMedicineRepository: ICustomerAddMedicineRepositorycs
          {
                    public readonly Ecommerecewebstedatabase _dbContext;
                    public CustomerAddMedicineRepository(Ecommerecewebstedatabase dbContext)
                    {
                              this._dbContext = dbContext;
                    }
                    public ResponseModel AddCustomerAddMedicine(CustomerAddMedicineModel customerAddMedicine)
                    {
                            var response = new ResponseModel();
                               try
                               {
                                         _dbContext.customerAddMedicineModels.Add(customerAddMedicine);  
                                         _dbContext.SaveChanges();
                                         response.status = true;
                                         response.responseMessage = "Customer added medicine successfully.";
                               }
                               catch (Exception ex)
                               {
                                         response.status = false;
                                         response.responseMessage = $"Error adding customer added medicine: {ex.Message}";
                               }
                               return response;
                    }
                    public ResponseModel GetAllCustomerAddMedicines()
                    {
                             var response = new ResponseModel();
                               try
                               {
                                         var customerAddedMedicines = _dbContext.customerAddMedicineModels.ToList();
                                         response.status = true;
                                         response.responseMessage = "Customer added medicines retrieved successfully.";
                                         response.Data = customerAddedMedicines;
                               }
                               catch (Exception ex)
                               {
                                         response.status = false;
                                         response.responseMessage = $"Error retrieving customer added medicines: {ex.Message}";
                               }
                               return response;
                    }
          }
}
