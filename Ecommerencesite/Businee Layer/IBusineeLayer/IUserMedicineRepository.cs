using CRUDAPPLICATION.ModelDTO;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.BusineeLayer
{
          public interface IUserMedicineRepository
          {

                    public ResponseModel CREATERegisterUser(UserMedicine userregistMedicine);
                    
                    ResponseModel LOGINUserMedicine(UserLogindto userLogindto);
                    public ResponseModel ViewUser(int id );// DETAILS 
                    public ResponseModel UpdateUserMedicine(UserMedicine userUpdateMedicine);
                    public ResponseModel DELETEUserMedicine(UserMedicine userdeleteMedicine);
                    public ResponseModel PlaceOrder(UserMedicine userOrder);
                    // public ResponseModel OrderList(UserMedicine userMedicine
                    public ResponseModel OrderList();// Usermedicine --- order list dat--All List
                    public List<UserMedicine> CUSTOMERUserList();// usermedicine list dta 

                    //forget password
                    Task<bool> ResetPasswordAsync(ForgetPasswordUserDto dto);




          }
}
