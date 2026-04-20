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

                    public void AddQRCashCodeModels(QRCashCodeModels qRCashCodeModels)
                    {
                           _ecommerecewebstedatabase.qRCashCodeModelss.Add(qRCashCodeModels);
                              _ecommerecewebstedatabase.SaveChanges();
                    }

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
          }
}
