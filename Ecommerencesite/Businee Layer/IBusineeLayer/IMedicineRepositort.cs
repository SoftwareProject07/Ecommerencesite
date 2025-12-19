using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IMedicineRepositort
          {
                    public ResponseModel lstmedicine();
                    public ResponseModel CreateMedicine(Medicine createMedicine);
                    public ResponseModel UpdateMedicine(Medicine updatemedicine);
                    public ResponseModel DeleteMedicine(int id);
                    public ResponseModel DetailsMedicine(int id);// searchMedicine 
                    public ResponseModel SearchMedicine(int id);// searchonlyMedicinename

          }
}
