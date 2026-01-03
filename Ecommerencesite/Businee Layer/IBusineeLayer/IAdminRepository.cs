using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IAdminRepository
          {


                    public ResponseModel CREATERegistoryAdmin(AdminREGMODEL adminREGMODEL);

                    public ResponseModel LOGINAdmin(AdminLogindto _adminlogindto);
                   // public ResponseModel Viewlogin(int id);// DETAILS 

          }
}
