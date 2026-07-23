using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer
{
          public interface IITrackingServiceRepository
          {
                    Task<bool> UpdateDeliveryLocationAsync(int orderId, decimal latitude, decimal longitude);
                    //   public void AddAddress(deliverypartnermodel adddeliverpartner);//delivery partner address add


                    //  Task<IActionResult> SaveAddress(DeliveryPartnerAddressDto dto)
          }
}
