using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class LanguageService : ILanguageService
          {
                    public readonly Ecommerecewebstedatabase _context;
                 //   private readonly List<string> _supportedLanguages = new() { "en", "hi", "ur" };

                    public LanguageService(Ecommerecewebstedatabase context)
                    {
                              this._context = context;
                    }

                    public List<choice_MultipleLanguageModel> AllCurrentLanguageAsync()
                    {
                              var listlanguarge = _context.choicemultiplelanguagemodel.ToList();
                              return listlanguarge;
                    }

                    //public List<choice_MultipleLanguageModel> AllCurrentLanguageAsync()
                    //{
                    //          var listlanguarge = _context.choicemultiplelanguagemodel
                    //              .DistinctBy(l => l.PreferredLanguage) // Assumes your property is named 'PreferredLanguage'
                    //              .ToList();

                    //          return listlanguarge;
                    //}
                    //public async Task<string> AllCurrentLanguageAsync()
                    //{
                    //          // Fetching the latest configuration from database (adjust table name as per your DB context)
                    //          // Example: Assuming you store it in a table, fetching the first or global record
                    //          var setting = await _context.choicemultiplelanguagemodel.FirstOrDefaultAsync();

                    //          return setting?.PreferredLanguage ?? "en"; // Default to 'en' if not found
                    //}

                    //public void CreateLanguage(choice_MultipleLanguageModel createmodel)
                    //{
                    //          _context.choicemultiplelanguagemodel.Add(createmodel);
                    //          _context.SaveChanges();
                    //}

                    //public void CreateLanguage(choice_MultipleLanguageModel createmodel)
                    //{
                    //          // Check if a record with the same preferred language already exists
                    //          bool exists = _context.choicemultiplelanguagemodel
                    //              .Any(l => l.PreferredLanguage.ToLower() == createmodel.PreferredLanguage.ToLower());

                    //          if (exists)
                    //          {
                    //                    // Agar pehle se maujoud hai, toh yahin se wapas ho jao (add mat karo)
                    //                    return;
                    //          }

                    //          // Add new record if it doesn't exist
                    //          _context.choicemultiplelanguagemodel.Add(createmodel);
                    //          _context.SaveChanges();
                    //}

                    public void  CreateLanguage(choice_MultipleLanguageModel createmodel)
                    {
                              // Pehle incoming data ko Trim() kar lo taaki extra spaces hat jayein
                              string incomingName = createmodel.PreferredLanguage.Trim();

                              // Database mein check karo (case-insensitive aur trim karke)
                              bool exists = _context.choicemultiplelanguagemodel
                                  .Any(l => l.PreferredLanguage.Trim().ToLower() == incomingName.ToLower());

                              if (exists)
                              {
                                        // Agar pehle se maujoud hai, toh message return karo
                                        return ;
                              }

                              // Agar nahi hai, toh save kar do
                              createmodel.PreferredLanguage = incomingName; // Clean version save karein
                              _context.choicemultiplelanguagemodel.Add(createmodel);
                              _context.SaveChanges();

                              return ;
                    }
                    public choice_MultipleLanguageModel DeleteLanguage(int id)
                    {
                              var deletrelanguage = _context.choicemultiplelanguagemodel.Where(s => s.Id == id).FirstOrDefault();
                              if (deletrelanguage != null)
                              {
                                        _context.choicemultiplelanguagemodel.Remove(deletrelanguage);
                                        _context.SaveChanges();
                              }
                              return deletrelanguage;
                    }

                    public choice_MultipleLanguageModel DetailsLanguage(int id)
                    {
                            var details = _context.choicemultiplelanguagemodel.Where(s=>s.Id==id).FirstOrDefault();
                              return details;
                    }

                    public void UpdateLanguageAsync(choice_MultipleLanguageModel model)
                    {
                             _context.choicemultiplelanguagemodel.Update(model);
                              _context.SaveChanges();
                    }

                    //void ILanguageService.CreateLanguage(choice_MultipleLanguageModel createmodel)
                    //{
                    //          throw new NotImplementedException();
                    //}

                    //public async Task<choice_MultipleLanguageModel> UpdateLanguageAsync(choice_MultipleLanguageModel model)
                    //{
                    //          // Validate business rule for allowed languages
                    //          //if (!_supportedLanguages.Contains(model.PreferredLanguage))
                    //          //{
                    //          //          throw new ArgumentException("Unsupported language code. Use 'en', 'hi', or 'ur'.");
                    //          //}

                    //          //// Check if record already exists in database
                    //          //   var existingSetting = await _context.choicemultiplelanguagemodel.FirstOrDefaultAsync();

                    //          //if (existingSetting == null)
                    //          //{
                    //          //          // If no record exists, create a new one
                    //          //          _context.choicemultiplelanguagemodel.Add(model);
                    //          //}
                    //          //else
                    //          //{
                    //          //          // Update existing record
                    //          //          existingSetting.PreferredLanguage = model.PreferredLanguage;
                    //          //          _context.choicemultiplelanguagemodel.Update(existingSetting);
                    //          //}

                    //          // Save changes to database asynchronously
                    //          //  await  _context.Update(model)
                    //          await _context.Update(model);
                    //          await _context.SaveChangesAsync();      

                    //          return model;
                    //}



          }
}