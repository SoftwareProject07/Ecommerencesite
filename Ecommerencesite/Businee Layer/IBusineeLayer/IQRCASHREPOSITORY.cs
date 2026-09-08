using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IQRCASHREPOSITORY
          {
                    public List<QRCashCodeModels> listqucasehmodel();
                    //public void AddQRCashCodeModels(QRCashCodeModels qRCashCodeModels);
                    public void UpdateQRCashCodeModels(QRCashCodeModels qRCashCodeModels);
                             public QRCashCodeModels DeleteQRCashCodeModels(int id);

                    Task<QRCashCodeModels> UploadQRCodeAsync(IFormFile file, string webRootPath);
                    Task<QRCashCodeModels?> GetQRCodeByIdAsync(int id);


          }
}
