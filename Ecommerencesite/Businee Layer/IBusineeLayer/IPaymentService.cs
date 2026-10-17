using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IPaymentService
          {
                    // 1. VPA Check / Validation
                    Task<bool> ValidateVpaAsync(string vpa);

                    // 2. UPI Payment Link / Order Generate
                    Task<UpiPaymentVPAResponse> CreateUpiPaymentAsync(UpiPaymentVPARequest request);
          }
}
