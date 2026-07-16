using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;



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
                              //..     ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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




                    //public void UpdateMedicine(Medicine updatemedicine)
                    //{
                    //          //  // 1. Pehle check karein ki kya is naam ki koi aur medicine pehle se hai?
                    //          //  // Hum current 'id' ko exclude ( != ) karenge taaki usi record se takrav na ho
                    //          //  var isDuplicate = dbcontext.medicinesss
                    //          //      .Any(x => x.Name.Trim().ToLower() == updatemedicine.Name.ToLower()
                    //          //                && x.id != updatemedicine.id
                    //          //                && x.STATUS == updatemedicine.STATUS);


                    //          //  //if (isDuplicate)
                    //          //  //{
                    //          //  //          return new ResponseModel
                    //          //  //          {
                    //          //  //                    status = false,
                    //          //  //                    responseMessage = "Duplicate Alert: Medicine   are already available."
                    //          //  //          };
                    //          //  //}

                    //          //  // 2. Existing record find karein
                    //          //  var medicine = dbcontext.medicinesss
                    //          //      .FirstOrDefault(x => x.id == updatemedicine.id && x.STATUS == 1);

                    //          //  if (medicine == null)
                    //          //  {
                    //          //            return new ResponseModel
                    //          //            {
                    //          //                      status = false,
                    //          //                      responseMessage = "Medicine not found"
                    //          //            };
                    //          //  }

                    //          //  // 3. Data update karein
                    //          //  medicine.Name = updatemedicine.Name;
                    //          //  medicine.Manufacturer = updatemedicine.Manufacturer;
                    //          //  medicine.UnitPrice = updatemedicine.UnitPrice;
                    //          //  medicine.Discount = updatemedicine.Discount;
                    //          //  medicine.Quantity = updatemedicine.Quantity;
                    //          //  medicine.ExpiryDate = updatemedicine.ExpiryDate;
                    //          //medicine.Image = updatemedicine.Image;
                    //          //  medicine.MedicinesType = updatemedicine.MedicinesType;
                    //          //  medicine.Type = updatemedicine.Type;
                    //          //  medicine.ItemMedicine = updatemedicine.ItemMedicine;
                    //          //  medicine.STATUS = updatemedicine.STATUS;

                    //          //  dbcontext.SaveChanges();

                    //          //  return new ResponseModel
                    //          //  {
                    //          //            status = true,
                    //          //            responseMessage = "Medicine Updated Successfully",
                    //          //            medicine = medicine
                    //          //  };



                    //          //dbcontext.medicinesss.Update(updatemedicine);
                    //          //dbcontext.SaveChanges();


                    //          if (updatemedicine == null)
                    //          {
                    //                    throw new ArgumentNullException(nameof(updatemedicine), "Medicine data cannot be null.");
                    //          }

                    //          // 2. Find the existing record
                    //          var existing = dbcontext.medicinesss.Find(updatemedicine.id);
                    //          if (existing == null)
                    //          {
                    //                    throw new KeyNotFoundException($"Medicine with ID {updatemedicine.id} was not found.");
                    //          }

                    //          // 3. Update the values
                    //          existing.id = updatemedicine.id;
                    //          existing.UserId = updatemedicine.UserId;
                    //          existing.Name = updatemedicine.Name;
                    //          existing.Manufacturer = updatemedicine.Manufacturer;

                    //          existing.UnitPrice = updatemedicine.UnitPrice ;
                    //          existing.Discount = updatemedicine.Discount;
                    //          existing.Quantity = updatemedicine.Quantity;
                    //          existing.ExpiryDate = updatemedicine.ExpiryDate;
                    //          existing.Image = updatemedicine.Image;
                    //          existing.STATUS = updatemedicine.STATUS;
                    //          existing.MedicinesType = updatemedicine.MedicinesType;
                    //          existing.ItemMedicine = updatemedicine.ItemMedicine;
                    //          existing.Type= updatemedicine.Type;
                    //          //existing.Dosage = medicine.Dosage;
                    //          //existing.StockQuantity = medicine.StockQuantity;

                    //          // 4. Save to database
                    //          dbcontext.SaveChanges();

                    //}


                    public void UpdateMedicine(Medicine medicine)
                    {
                              if (medicine == null)
                              {
                                        throw new ArgumentNullException(nameof(medicine), "Medicine data cannot be null.");
                              }

                              // 1. Database se pehle ka original data nikalen
                              var existing = dbcontext.medicinesss.Find(medicine.id);
                              if (existing == null)
                              {
                                        throw new KeyNotFoundException($"Medicine with ID {medicine.id} not found.");
                              }

                              // 2. UserId aur Status ko safe rakhein (Agar request me 0 aaye toh purana hi rehne dein)
                              if (medicine.UserId > 0) existing.UserId = medicine.UserId;

                              // Sabse important: Agar status request me 0 hai aur purana status 1 tha, toh use 1 hi rehne dein
                              // Taki list se data gayab na ho
                              if (medicine.STATUS != 0)
                              {
                                        existing.STATUS = medicine.STATUS;
                              }

                              // 3. Baaki fields ko tabhi update karein jab wo "string" ya empty na hon
                              if (!string.IsNullOrEmpty(medicine.Name) && medicine.Name != "string")
                                        existing.Name = medicine.Name;

                              if (!string.IsNullOrEmpty(medicine.Manufacturer) && medicine.Manufacturer != "string")
                                        existing.Manufacturer = medicine.Manufacturer;

                              if (!string.IsNullOrEmpty(medicine.MedicinesType) && medicine.MedicinesType != "string")
                                        existing.MedicinesType = medicine.MedicinesType;

                              if (!string.IsNullOrEmpty(medicine.ItemMedicine) && medicine.ItemMedicine != "string")
                                        existing.ItemMedicine = medicine.ItemMedicine;

                              if (!string.IsNullOrEmpty(medicine.Type) && medicine.Type != "string")
                                        existing.Type = medicine.Type;

                              if (!string.IsNullOrEmpty(medicine.Image) && medicine.Image != "string")
                                        existing.Image = medicine.Image;

                              // Numbers aur Dates ko update karein
                              if (medicine.UnitPrice > 0) existing.UnitPrice = medicine.UnitPrice;
                              if (medicine.Discount >= 0) existing.Discount = medicine.Discount;
                              if (medicine.Quantity >= 0) existing.Quantity = medicine.Quantity;

                              // Valid date check
                              if (medicine.ExpiryDate != default) existing.ExpiryDate = medicine.ExpiryDate;

                              // 4. Save Changes
                              dbcontext.SaveChanges();
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
                    //public List<Medicine> GetAllMedicine()
                    //{
                    //          var list = dbcontext.medicinesss.ToList();
                    //          return list;
                    //}



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
               
                    public async Task<List<Medicine>> ParseMedicineExcelAsync(Stream fileStream)
                    {
                              var medicinesList = new List<Medicine>();

                              // ⭐️ EPPlus 8+ के लिए बिना किसी एरर के 100% सही और परमानेंट लाइन ⭐️
                              //OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseInfo.NonCommercial;
                              OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                              using (var package = new OfficeOpenXml.ExcelPackage(fileStream))
                              {
                                        var worksheet = package.Workbook.Worksheets[0];
                                        if (worksheet == null) return medicinesList;

                                        int rowCount = worksheet.Dimension.Rows;

                                        for (int row = 2; row <= rowCount; row++)
                                        {
                                                  var name = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
                                                  if (string.IsNullOrEmpty(name)) continue;

                                                  var medicine = new Medicine
                                                  {
                                                            Name = name,
                                                            Manufacturer = worksheet.Cells[row, 2].Value?.ToString()?.Trim() ?? "Generic",
                                                            UnitPrice = decimal.TryParse(worksheet.Cells[row, 3].Value?.ToString(), out decimal price) ? price : 0.00m,
                                                            Discount = decimal.TryParse(worksheet.Cells[row, 4].Value?.ToString(), out decimal discount) ? discount : 0.00m,
                                                            Quantity = int.TryParse(worksheet.Cells[row, 5].Value?.ToString(), out int qty) ? qty : 100,
                                                            ExpiryDate = worksheet.Cells[row, 6].Value?.ToString()?.Trim() ?? "01/12/2029",
                                                            Image = worksheet.Cells[row, 7].Value?.ToString()?.Trim() ?? "",
                                                            STATUS = int.TryParse(worksheet.Cells[row, 8].Value?.ToString(), out int status) ? status : 1,
                                                            MedicinesType = worksheet.Cells[row, 9].Value?.ToString()?.Trim() ?? "Tablet",
                                                            ItemMedicine = worksheet.Cells[row, 10].Value?.ToString()?.Trim() ?? "General",
                                                            Type = worksheet.Cells[row, 11].Value?.ToString()?.Trim() ?? "General"
                                                  };

                                                  medicinesList.Add(medicine);
                                        }
                              }
                              return await Task.FromResult(medicinesList);
                    }
                    // [B] डेटाबेस में बल्क इन्सर्ट करने का लॉजिक
                    //public async Task<int> BulkInsertMedicinesAsync(List<Medicine> medicines)
                    //{
                    //          if (medicines == null || !medicines.Any()) return 0;

                    //          await dbcontext.medicinesss.AddRangeAsync(medicines);
                    //          return await dbcontext.SaveChangesAsync();
                    //}

                    public async Task<int> BulkInsertMedicinesAsync(List<Medicine> medicines)
                    {
                              if (medicines == null || !medicines.Any()) return 0;

                              // Step A: एक्सेल फ़ाइल के अंदर से डुप्लीकेट हटाएँ (अगर एक्सेल में एक ही नाम 2 बार हो)
                              // हम दवा के Name को Case-Insensitive (छोटे-बड़े अक्षरों का अंतर मिटाकर) ग्रुप कर रहे हैं
                              var uniqueIncomingMedicines = medicines
                                  .GroupBy(m => m.Name?.ToLower().Trim())
                                  .Select(g => g.First())
                                  .ToList();

                              // Step B: डेटाबेस में पहले से मौजूद सभी दवाओं के नाम की लिस्ट निकालें
                              var existingDbNames = await dbcontext.medicinesss
                                  .Select(m => m.Name.ToLower().Trim())
                                  .ToListAsync();

                              // Step C: सिर्फ उन्हीं दवाओं को फ़िल्टर करें जो डेटाबेस में पहले से मौजूद नहीं हैं (New Only)
                              var newMedicinesToInsert = uniqueIncomingMedicines
                                  .Where(m => !existingDbNames.Contains(m.Name?.ToLower().Trim()))
                                  .ToList();

                              // अगर कोई भी नई दवा नहीं मिली (सब डुप्लीकेट थीं), तो 0 रिटर्न करें
                              if (!newMedicinesToInsert.Any())
                              {
                                        return 0;
                              }

                              // Step D: सिर्फ नई (Unique) दवाओं को डेटाबेस में एक साथ सेव करें
                              await dbcontext.medicinesss.AddRangeAsync(newMedicinesToInsert);

                              // बदलावों को सेव करें और प्रभावित रो (Rows) की संख्या रिटर्न करें
                              return await dbcontext.SaveChangesAsync();
                    }

                  
          }
}




