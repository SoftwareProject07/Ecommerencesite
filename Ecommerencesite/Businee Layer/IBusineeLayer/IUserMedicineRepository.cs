using CRUDAPPLICATION.ModelDTO;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.BusineeLayer
{
          public interface IUserMedicineRepository
          {

                    public ResponseModel CREATERegisterUser(UserMedicine userregistMedicine);
                    
                    ResponseModel LOGINUserMedicine(UserLogindto userLogindto);
                    public UserMedicine Customerprofile(int userId);// DETAILS 
                    public ResponseModel UpdateUserMedicine(UserMedicine userUpdateMedicine);
                    public ResponseModel DELETEUserMedicine(UserMedicine userdeleteMedicine);
                    public ResponseModel PlaceOrder(UserMedicine userOrder);
                    // public ResponseModel OrderList(UserMedicine userMedicine
                    public ResponseModel OrderList();// Usermedicine --- order list dat--All List
                    public List<UserMedicine> CUSTOMERUserList();// usermedicine list dta 
                 //   public UserMedicine CustomerProfile(int userid);
                    //forget password
                    Task<bool> ResetPasswordAsync(ForgetPasswordUserDto dto);




          }
}
