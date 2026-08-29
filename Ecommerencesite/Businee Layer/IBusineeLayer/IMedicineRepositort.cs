using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IMedicineRepositort
          {
                
                   public List<Medicine>  GetAllMedicine();
              //        ..  public  void  CreateMedicineAsync( Medicine medicine, IFormFile image);
                    
                  public Task CreateMedicineAsync(Medicine medicine, IFormFile image);
                    public void  UpdateMedicine(Medicine updatemedicine);

                     public ResponseModel DeleteMedicine(int id);
                 //   public Medicine Deeltemedicine(int id);
                    public ResponseModel DetailsMedicine(int id);// searchMedicine 
                    public ResponseModel SearchMedicine(int id);// searchonlyMedicinename
                                                               
                 
                    public ResponseModel GetUserSpecificMedicines(int loggedInUserId);

                    Task<List<Medicine>> ParseMedicineExcelAsync(Stream fileStream);

                    Task<int> BulkInsertMedicinesAsync(List<Medicine> medicines);



          }
}
