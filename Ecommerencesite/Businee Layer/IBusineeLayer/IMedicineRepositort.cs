using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IMedicineRepositort
          {
                    //public List<Medicine> lstmedicine();
                    public ResponseModel GetAllMedicine();  
                    //  public ResponseModel CreateMedicine(Medicine createMedicine);
                    Task<ResponseModel> CreateMedicineAsync(Medicine medicine, IFormFile image);
                    public ResponseModel UpdateMedicine(Medicine updatemedicine);
                    public ResponseModel DeleteMedicine(int id);
                    public ResponseModel DetailsMedicine(int id);// searchMedicine 
                    public ResponseModel SearchMedicine(int id);// searchonlyMedicinename
                                                                // public Medicine MEDINEVIEW(int medicineid);
                    Task<string> SaveImageAsync(IFormFile image);
                    public ResponseModel GetUserSpecificMedicines(int loggedInUserId);
                    //public void  AddMedicineModel(AddModelMasterTypedto addmedicinemodel);
                   // Task<bool> AddMedicineModel(AddModelMasterTypedto dto);

          }
}
