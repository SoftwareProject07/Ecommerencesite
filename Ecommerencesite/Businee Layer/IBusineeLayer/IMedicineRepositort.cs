using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IMedicineRepositort
          {
                    //public List<Medicine> lstmedicine();
                 //   public List<Medicine> GetAllMedicine();
                   public ResponseModel GetAllMedicine();
                    //  public ResponseModel CreateMedicine(Medicine createMedicine);
                    Task<ResponseModel> CreateMedicineAsync(Medicine medicine, IFormFile image);
                    public void  UpdateMedicine(Medicine updatemedicine);
                    //public ResponseModel UpdateMedicineAsync(Medicine medicine);

                    public ResponseModel DeleteMedicine(int id);
                    public ResponseModel DetailsMedicine(int id);// searchMedicine 
                    public ResponseModel SearchMedicine(int id);// searchonlyMedicinename
                                                                // public Medicine MEDINEVIEW(int medicineid);
                    //Task<string> SaveImageAsync(IFormFile image);
                    public ResponseModel GetUserSpecificMedicines(int loggedInUserId);

                    // upload medicine list data  excel formate 
                    Task<List<Medicine>> ParseMedicineExcelAsync(Stream fileStream);

                    Task<int> BulkInsertMedicinesAsync(List<Medicine> medicines);
                 //   public ResponseModel UpdateMedicineit(Medicine medicine);



          }
}
