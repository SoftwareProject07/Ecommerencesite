using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.MODELDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;


//DateTime expiryDateParsed;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{

          public class MedicineRepository : IMedicineRepositort
          {
                    private readonly Ecommerecewebstedatabase dbcontext;
                    private readonly IWebHostEnvironment _environment;
                    public MedicineRepository(Ecommerecewebstedatabase _dbcontext, IWebHostEnvironment environment)
                    {
                              this.dbcontext = _dbcontext;
                              this._environment = environment;

                    }
                    public async Task<ResponseModel> CreateMedicineAsync(Medicine medicine, IFormFile image)
                    {
                              ResponseModel response = new ResponseModel();

                              // 1. Validation: Name check
                              if (string.IsNullOrWhiteSpace(medicine.Name))
                              {
                                        response.status = false;
                                        response.responseMessage = "Medicine name cannot be empty.";
                                        return response;
                              }

                              // 2. Duplicate Check (Case-Insensitive)
                              bool alreadyExists = await dbcontext.medicinesss
                                  .AnyAsync(m => m.Name.ToLower() == medicine.Name.Trim().ToLower());

                              if (alreadyExists)
                              {
                                        response.status = false;
                                        response.responseMessage = "This medicine already exists in the records.";
                                        return response;
                              }

                              // 3. Image Upload
                              string imageUrl = null;
                              if (image != null && image.Length > 0)
                              {
                                        imageUrl = await UploadImageToImgBB(image);
                              }

                              // 4. Save Logic
                              medicine.Image = imageUrl ?? "https://via.placeholder.com/300x300.png?text=No+Image";
                              medicine.STATUS = 1;
                              medicine.Name = medicine.Name.Trim();

                              // ✅ ItemMedicine automatically mapped from Frontend FormData "ItemMedicine"

                              try
                              {
                                        dbcontext.medicinesss.Add(medicine);
                                        await dbcontext.SaveChangesAsync();

                                        response.status = true;
                                        response.responseMessage = "Medicine added successfully!";
                              }
                              catch (Exception ex)
                              {
                                        response.status = false;
                                        response.responseMessage = "Database Error: " + ex.Message;
                              }

                              return response;
                    }

                    private Task<string> UploadImageToImgBB(IFormFile image)
                    {
                              // Instead of uploading, just return a placeholder image URL
                              string placeholderUrl = "https://via.placeholder.com/300x300.png?text=Medicine+Image";
                              return Task.FromResult(placeholderUrl);
                    }


                    public ResponseModel DeleteMedicine(int id)
                    {
                              var medicine = dbcontext.medicinesss.Where(x => x.id == id).FirstOrDefault();

                              if (medicine == null)
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Medicine not found"
                                        };
                              }

                              // ✅ SOFT DELETEs
                              medicine.STATUS = 1;
                              dbcontext.medicinesss.Remove(medicine);
                              dbcontext.SaveChanges();

                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "Medicine deleted successfully"
                              };


                              //          dbcontext.medicinesss.Remove(medicine);
                              //          dbcontext.SaveChanges();
                              //}

                    }

                    public ResponseModel DetailsMedicine(int id)
                    {
                              var details = new ResponseModel();
                              try
                              {
                                        var detail = dbcontext.medicinesss.Where(m => m.id == id).FirstOrDefault();
                                        details.status = true;
                                        details.responseMessage = "Medicine Details successfully";
                                        details.Data = detail;

                              }
                              catch (Exception ex)
                              {
                                        details.status = false;
                                        details.responseMessage = ex.Message;
                              }
                              return details;

                    }

              
                    public ResponseModel SearchMedicine(int id)
                    {
                              var SearchMedicine = new ResponseModel();
                              try
                              {
                                        var SearchMedicineS = dbcontext.medicinesss.Where(m => m.id == id).FirstOrDefault();
                                        SearchMedicine.status = true;
                                        SearchMedicine.responseMessage = "Medicine Search successfully";
                                        SearchMedicine.Data = SearchMedicineS;

                              }
                              catch (Exception ex)
                              {
                                        SearchMedicine.status = false;
                                        SearchMedicine.responseMessage = ex.Message;
                              }
                              return SearchMedicine;
                    }




                    public ResponseModel UpdateMedicine(Medicine updatemedicine)
                    {
                              // 1. Pehle check karein ki kya is naam ki koi aur medicine pehle se hai?
                              // Hum current 'id' ko exclude ( != ) karenge taaki usi record se takrav na ho
                              var isDuplicate = dbcontext.medicinesss
                                  .Any(x => x.Name.Trim().ToLower() == updatemedicine.Name.ToLower()
                                            && x.id != updatemedicine.id
                                            && x.STATUS == updatemedicine.STATUS);

                         
                              if (isDuplicate)
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Duplicate Alert: Medicine   are already available."
                                        };
                              }

                              // 2. Existing record find karein
                              var medicine = dbcontext.medicinesss
                                  .FirstOrDefault(x => x.id == updatemedicine.id && x.STATUS == 1);

                              if (medicine == null)
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Medicine not found"
                                        };
                              }

                              // 3. Data update karein
                              medicine.Name = updatemedicine.Name;
                              medicine.Manufacturer = updatemedicine.Manufacturer;
                              medicine.UnitPrice = updatemedicine.UnitPrice;
                              medicine.Discount = updatemedicine.Discount;
                              medicine.Quantity = updatemedicine.Quantity;
                              medicine.ExpiryDate = updatemedicine.ExpiryDate;
                            medicine.Image = updatemedicine.Image;
                              medicine.MedicinesType = updatemedicine.MedicinesType;
                              medicine.Type = updatemedicine.Type;
                              medicine.ItemMedicine = updatemedicine.ItemMedicine;
                              medicine.STATUS = updatemedicine.STATUS;

                              dbcontext.SaveChanges();

                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "Medicine Updated Successfully",
                                        medicine = medicine
                              };
                    }


                    public ResponseModel GetAllMedicine()
                    {
                              ResponseModel response = new ResponseModel();

                              // Fix: .ToLower() use karke grouping karein taaki Case-Sensitivity ka issue solve ho jaye
                              var medicineList = dbcontext.medicinesss
                                                  .Where(m => m.STATUS == 1)
                                                  .AsEnumerable() // Memory mein lakar filter karne ke liye (Case-insensitive support)
                                                  .GroupBy(m => m.Name.Trim().ToLower())
                                                  .Select(g => g.First())
                                                  .ToList();

                              if (medicineList != null && medicineList.Any())
                              {
                                        response.status = true;
                                        response.responseMessage = "Success";
                                        response.LSTmedicines = medicineList;
                              }
                              else
                              {
                                        response.status = false;
                                        response.responseMessage = "No medicines found.";
                              }

                              return response;
                    }


                    public ResponseModel GetUserSpecificMedicines(int loggedInUserId)
                    {
                              ResponseModel response = new ResponseModel();
                              try
                              {
                                        // 1. Pehle filter karein ki STATUS active ho aur UserId matching ho
                                        // 2. Phir Name ke base par Group karein taaki us user ko duplicate na dikhe
                                        var medicineList = dbcontext.medicinesss
                                                                    .Where(m => m.STATUS == 1 && m.UserId == loggedInUserId)
                                                                    .GroupBy(m => m.Name.Trim().ToLower()) // Name se grouping
                                                                    .Select(g => g.FirstOrDefault()) // Har group ka pehla record
                                                                    .ToList();

                                        if (medicineList != null && medicineList.Any())
                                        {
                                                  response.status = true;
                                                  response.responseMessage = "User specific unique medicines fetched.";
                                                  response.LSTmedicines = medicineList;
                                        }
                                        else
                                        {
                                                  response.status = false;
                                                  response.responseMessage = "Is user ke liye koi medicine nahi mili.";
                                                  response.LSTmedicines = new List<Medicine>();
                                        }
                              }
                              catch (Exception ex)
                              {
                                        response.status = false;
                                        response.responseMessage = "Error: " + ex.Message;
                              }

                              return response;
                    }

                 


          }


}

