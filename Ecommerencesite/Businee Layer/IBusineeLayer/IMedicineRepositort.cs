using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IMedicineRepositort
          {
                    public List<Medicine> lstmedicine();
                    //public ResponseModel CreateMedicine(Medicine createMedicine);
                    Task<bool> CreateMedicineAsync(Medicine medicine, IFormFile image);
                    public ResponseModel UpdateMedicine(Medicine updatemedicine);
                    public ResponseModel DeleteMedicine(int id);
                    public ResponseModel DetailsMedicine(int id);// searchMedicine 
                    public ResponseModel SearchMedicine(int id);// searchonlyMedicinename

          }
}
