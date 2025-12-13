using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.BusineeLayer
{
          public interface IUserMedicineRepository
          {

                    public ResponseModel CREATERegisterUser(UserMedicine userregistMedicine);
                    public ResponseModel LOGINUserMedicine(UserLogindto _userlogindto);
                    public ResponseModel ViewUser(int id );// DETAILS 
                    public ResponseModel UpdateUserMedicine(UserMedicine userUpdateMedicine);
                    public ResponseModel DELETEUserMedicine(UserMedicine userdeleteMedicine);
                    public ResponseModel PlaceOrder(UserMedicine userOrder);
                    // public ResponseModel OrderList(UserMedicine userMedicine
                    public ResponseModel OrderList();// Usermedicine --- order list dat
                    public ResponseModel UserList();// usermedicine list dta 



          }
}
