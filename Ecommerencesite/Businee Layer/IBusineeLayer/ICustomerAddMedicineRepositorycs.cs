using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface ICustomerAddMedicineRepositorycs
          {
                    public ResponseModel AddCustomerAddMedicine(CustomerAddMedicineModel customerAddMedicine);//customer side
                     public ResponseModel GetAllCustomerAddMedicines();//Admin side
          }
}
