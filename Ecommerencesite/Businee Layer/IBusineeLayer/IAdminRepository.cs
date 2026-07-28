using Azure;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IAdminRepository
          {


                    public ResponseModel  CREATERegistoryAdmin(AdminREGMODEL adminREGMODEL);

                    public ResponseModel LOGINAdmin(AdminLogindto _adminlogindto);
                    public ResponseModel UPDATERegistoryAdmin(AdminREGMODEL adminREGMODEL);
                     public ResponseModel DeleteAdmin(int id);
                    public ResponseModel GETRegistoryAdmin(int id);
                     public ResponseModel GETALLRegistoryAdmin();
                    // public ResponseModel Viewlogin(int id);// DETAILS 


                    //Master Admin type add option 
                    public void AddAdminType(AdminTypeModel adminTypeModel);
                    public List<AdminTypeModel> typelist();
                    public void UpdateAdminType(AdminTypeModel adminTypeModel);
                    public AdminTypeModel DeleteAdmintype(int id);
                    public AdminTypeModel GetAdminTypeByName(int id);


          }
}
