using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class LicenseService : ILicenseService
          {
                    private readonly Ecommerecewebstedatabase _context;

                    public LicenseService(Ecommerecewebstedatabase context)
                    {
                              _context = context;
                    }

                    //public bool ValidateClientLicense(int clientId)
                    //{
                    //          var license = _context.ClientLicenses.FirstOrDefault(c => c.Id == clientId);
                    //          if (license == null)
                    //          {
                    //                    return false;
                    //          }
                    //          return license.IsAllowed;
                    //}


                    public bool ValidateClientLicense(int clientId)
                    {
                              // ==========================================
                              // OPTION A: Direct Code se ON/OFF karna ho toh:
                              // (Yahan true ya false karke GitHub par push/publish kar dein)
                              // ==========================================
                              bool remoteSwitch = false ; //true                            // Yahan false kar denge toh sab jagah band ho jayega!
                              return remoteSwitch;

                    }
          }
