using LabTestApp.Models;

namespace Ecommerencesite.Businee_Layer.IBusineeLayer.LABTESTIBUSINESSLAYER
{
          public interface IOfferTestBusiness
          {
                    Task<List<OfferTestModel>> GetAllOffersAsync();
                    Task<OfferTestModel> GetOfferByIdAsync(int id);
                    Task<List<OfferTestModel>> SearchOffersAsync(string keyword);
                    Task<bool> CreateOfferAsync(OfferTestModel model);
                    Task<bool> UpdateOfferAsync(OfferTestModel model);
                    Task<bool> DeleteOfferAsync(int id);
          }
}
