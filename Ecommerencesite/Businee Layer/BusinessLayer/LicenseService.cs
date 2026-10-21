using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class LicenseService: ILicenseService
          {
                    private readonly Ecommerecewebstedatabase _context;

                    public LicenseService(Ecommerecewebstedatabase context)
                    {
                              _context = context;
                    }

                    public bool ValidateClientLicense(int clientId)
                    {
                              var license = _context.ClientLicenses.FirstOrDefault(c => c.Id == clientId);
                              if (license == null)
                              {
                                        return false;
                              }
                              return license.IsAllowed;
                    }
          }
}