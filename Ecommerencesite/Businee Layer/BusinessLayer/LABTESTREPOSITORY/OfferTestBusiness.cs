using Ecommerencesite.Businee_Layer.IBusineeLayer.LABTESTIBUSINESSLAYER;
using Ecommerencesite.Database;
using LabTestApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class OfferTestBusiness : IOfferTestBusiness
          {
                    private readonly Ecommerecewebstedatabase _context;

                    public OfferTestBusiness(Ecommerecewebstedatabase context)
                    {

                           this.   _context = context;
                    }

                    // 1. Get All Offer Tests (Dynamic from DB)
                    public async Task<List<OfferTestModel>> GetAllOffersAsync()
                    {
                              return await _context.OfferTestModels.ToListAsync();
                    }

                    // 2. Get Offer Test Details By ID (Dynamic from DB)
                    public async Task<OfferTestModel> GetOfferByIdAsync(int id)
                    {
                              return await _context.OfferTestModels.FirstOrDefaultAsync(x => x.Id == id);
                    }

                    // 3. Search Offer Tests by Keyword (Dynamic from DB)
                    public async Task<List<OfferTestModel>> SearchOffersAsync(string keyword)
                    {
                              if (string.IsNullOrWhiteSpace(keyword))
                              {
                                        return await GetAllOffersAsync();
                              }

                              return await _context.OfferTestModels
                                  .Where(x => x.TestName.Contains(keyword) || x.Description.Contains(keyword))
                                  .ToListAsync();
                    }

                    // 4. Create New Offer Test (Dynamic Database Insert)
                    public async Task<bool> CreateOfferAsync(OfferTestModel model)
                    {
                              try
                              {
                                        await _context.OfferTestModels.AddAsync(model);
                                        await _context.SaveChangesAsync();
                                        return true;
                              }
                              catch (Exception)
                              {
                                        return false;
                              }
                    }

                    // 5. Update Existing Offer Test (Dynamic Database Update)
                    public async Task<bool> UpdateOfferAsync(OfferTestModel model)
                    {
                              var existing = await _context.OfferTestModels.FirstOrDefaultAsync(x => x.Id == model.Id);
                              if (existing == null) return false;

                              existing.TestName = model.TestName;
                              existing.Description = model.Description;
                              existing.OriginalPrice = model.OriginalPrice;
                              existing.OfferPrice = model.OfferPrice;
                              existing.DiscountPercentage = model.DiscountPercentage;
                              existing.ImageUrl = model.ImageUrl;
                              existing.StartDate = model.StartDate;
                              existing.EndDate = model.EndDate;
                              existing.IsActive = model.IsActive;

                              _context.OfferTestModels.Update(existing);
                              await _context.SaveChangesAsync();
                              return true;
                    }

                    // 6. Delete Offer Test (Dynamic Database Delete)
                    public async Task<bool> DeleteOfferAsync(int id)
                    {
                              var item = await _context.OfferTestModels.FirstOrDefaultAsync(x => x.Id == id);
                              if (item == null) return false;

                              _context.OfferTestModels.Remove(item);
                              await _context.SaveChangesAsync();
                              return true;
                    }
          }
}