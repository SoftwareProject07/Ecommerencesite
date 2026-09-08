using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class QRCASHREPOSITORY: IQRCASHREPOSITORY
          {
                    public readonly Ecommerecewebstedatabase _ecommerecewebstedatabase;
                    public QRCASHREPOSITORY(Ecommerecewebstedatabase ecommerecewebstedatabase)
                    {
                              this._ecommerecewebstedatabase= ecommerecewebstedatabase;
                    }

                    //public void AddQRCashCodeModels(QRCashCodeModels qRCashCodeModels)
                    //{
                    //       _ecommerecewebstedatabase.qRCashCodeModelss.Add(qRCashCodeModels);
                    //          _ecommerecewebstedatabase.SaveChanges();
                    //}

                    public QRCashCodeModels DeleteQRCashCodeModels(int id)
                    {
                            var qRCashCodeModels = _ecommerecewebstedatabase.qRCashCodeModelss.Where(s=>s.QRcashcodeid==id).FirstOrDefault();
                              if (qRCashCodeModels != null)
                              {
                                        _ecommerecewebstedatabase.qRCashCodeModelss.Remove(qRCashCodeModels);
                                        _ecommerecewebstedatabase.SaveChanges();
                              }
                              return qRCashCodeModels;
                    }

                    public async Task<QRCashCodeModels?> GetQRCodeByIdAsync(int id)
                    {
                              return await _ecommerecewebstedatabase.qRCashCodeModelss.FindAsync(id);
                    }

                    public List<QRCashCodeModels> listqucasehmodel()
                    {
                            var list= _ecommerecewebstedatabase.qRCashCodeModelss.ToList();
                              return list;        
                    }

                    public void UpdateQRCashCodeModels(QRCashCodeModels qRCashCodeModels)
                    {
                            _ecommerecewebstedatabase.qRCashCodeModelss.Update(qRCashCodeModels);
                              _ecommerecewebstedatabase.SaveChanges();
                    }

                    public async Task<QRCashCodeModels> UploadQRCodeAsync(IFormFile file, string webRootPath)
                    {
                              if (file == null || file.Length == 0)
                                        throw new ArgumentException("Invalid file.");

                              // Define folder path: wwwroot/uploads/qrcodes
                              var uploadsFolder = Path.Combine(webRootPath, "uploads", "qrcodes");
                              if (!Directory.Exists(uploadsFolder))
                              {
                                        Directory.CreateDirectory(uploadsFolder);
                              }

                              // Generate unique file name to prevent overwriting
                              var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                              var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                              using (var fileStream = new FileStream(filePath, FileMode.Create))
                              {
                                        await file.CopyToAsync(fileStream);
                              }

                              // Save relative path to database
                              var qrCodeModel = new QRCashCodeModels
                              {
                                        QRCodeImageUrl = $"/uploads/qrcodes/{uniqueFileName}"
                              };

                              object value = _ecommerecewebstedatabase.qRCashCodeModelss.Add(qrCodeModel);
                              await _ecommerecewebstedatabase.SaveChangesAsync();

                              return qrCodeModel;
                    }
          }
}
