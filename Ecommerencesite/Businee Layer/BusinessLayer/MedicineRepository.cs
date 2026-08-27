using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Microsoft.AspNetCore.Mvc;
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

      



                    public void CreateMedicineAsync(Medicine medicine, IFormFile image)
                    {
                              try
                              {
                                        if (image != null && image.Length > 0)
                                        {
                                                  // 1. Folder path define karein
                                                  string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                                                  if (!Directory.Exists(uploadsFolder))
                                                  {
                                                            Directory.CreateDirectory(uploadsFolder);
                                                  }

                                                  // 2. Unique file name banayein taaki naam repeat na ho
                                                  string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(image.FileName);
                                                  string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                                                  // 3. File ko server par save karein (Synchronous CopyTo use kiya hai)
                                                  using (var fileStream = new FileStream(filePath, FileMode.Create))
                                                  {
                                                            image.CopyTo(fileStream); // Note: CopyToAsync ki jagah CopyTo use hoga
                                                  }

                                                  // 4. Medicine model ke Image property mein relative path save karein
                                                  medicine.Image = $"/uploads/{uniqueFileName}";
                                        }
                                        else
                                        {
                                                  medicine.Image = null; // Agar image nahi aayi toh null
                                        }

                                        // Database mein data add aur save karna (Synchronous SaveChanges)
                                        dbcontext.medicinesss.Add(medicine);
                                        dbcontext.SaveChanges(); // Note: SaveChangesAsync ki jagah SaveChanges use hoga
                              }
                              catch (Exception ex)
                              {
                                        // Agar void hai toh error handle karne ke liye Console ya Throw kar sakte hain
                                        Console.WriteLine("Error: " + ex.Message);
                                        throw;
                              }
                    }
                    
                    private async Task<string> UploadImageToImgBB(IFormFile image)
                    {
                              try
                              {
                                        // 1. Root path mein 'uploads' folder ka path banayein
                                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

                                        if (!Directory.Exists(uploadsFolder))
                                        {
                                                  Directory.CreateDirectory(uploadsFolder);
                                        }

                                        // 2. Unique file name banayein taaki duplicate naam ki file clash na kare
                                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(image.FileName);
                                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                                        // 3. File ko server ki physical memory/folder mein copy karein
                                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                                        {
                                                  await image.CopyToAsync(fileStream);
                                        }

                                        // 4. Database ke liye sirf file ka naam ya relative path return karein
                                        return uniqueFileName;
                              }
                              catch (Exception)
                              {
                                        return null;
                              }
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






                    public void UpdateMedicine(Medicine updateMedicine)
                    {
                              if (updateMedicine == null)
                              {
                                        throw new ArgumentNullException(nameof(updateMedicine), "Medicine data cannot be null.");
                              }

                              if (updateMedicine.id <= 0)
                              {
                                        throw new ArgumentNullException(nameof(updateMedicine.id), "Invalid Medicine ID provided.");
                              }

                              // 1. Check if the record actually exists in the database first
                              var existingMedicine = dbcontext.medicinesss.Find(updateMedicine.id);

                              if (existingMedicine == null)
                              {
                                        throw new KeyNotFoundException($"Medicine with ID {updateMedicine.id} was not found in the database.");
                              }

                              // 2. Explicitly map/update properties
                              existingMedicine.Name = updateMedicine.Name;
                              existingMedicine.Manufacturer = updateMedicine.Manufacturer;
                              existingMedicine.UnitPrice = updateMedicine.UnitPrice;
                              existingMedicine.Quantity = updateMedicine.Quantity;
                              existingMedicine.ExpiryDate = updateMedicine.ExpiryDate;

                              // 🔥 Image update logic: Agar frontend se nayi image string aayi hai toh hi update karein, warna purani retain rakhein
                              if (!string.IsNullOrEmpty(updateMedicine.Image))
                              {
                                        existingMedicine.Image = updateMedicine.Image;
                              }

                              existingMedicine.ItemMedicine = updateMedicine.ItemMedicine;
                              existingMedicine.Type = updateMedicine.Type;
                              existingMedicine.MedicinesType = updateMedicine.MedicinesType;
                              existingMedicine.Discount = updateMedicine.Discount;
                              existingMedicine.STATUS = updateMedicine.STATUS;

                              // 3. Save changes
                              dbcontext.SaveChanges();
                    }


                    public List<Medicine> GetAllMedicine()
                    {
                              try
                              {
                                        var medicineList = dbcontext.medicinesss
                                                                   .Where(m => m.STATUS == 1)
                                                                   .AsEnumerable()
                                                                   .GroupBy(m => (m.Name ?? "").Trim().ToLower())
                                                                   .Select(g => g.First())
                                                                   .ToList();

                                        // Har ek medicine ki image path ko format karna
                                        foreach (var med in medicineList)
                                        {
                                                  if (!string.IsNullOrEmpty(med.Image))
                                                  {
                                                            // Safety Check: Agar image base64 string ya bohot lambi string hai (jo ki file path nahi hai), toh use skip ya clear kar dein
                                                            if (med.Image.StartsWith("data:image") || med.Image.Length > 300)
                                                            {
                                                                      // Agar base64 hai toh yahan handle kar sakte hain ya blank chhor sakte hain
                                                                      continue;
                                                            }

                                                            // Agar already http ya https se start ho raha hai toh koi change mat karo
                                                            if (med.Image.StartsWith("http://") || med.Image.StartsWith("https://"))
                                                            {
                                                                      continue;
                                                            }

                                                            // Clean backslashes to forward slashes (Windows paths fix karne ke liye)
                                                            string cleanImage = med.Image.Replace("\\", "/").Trim();

                                                            // Agar path 'uploads/' se shuru ho raha hai toh use hata kar standard banayein
                                                            if (cleanImage.StartsWith("uploads/"))
                                                            {
                                                                      cleanImage = cleanImage.Substring("uploads/".Length);
                                                            }

                                                            // Agar path '/' se start nahi ho raha toh slash add karein
                                                            if (!cleanImage.StartsWith("/"))
                                                            {
                                                                      cleanImage = "/" + cleanImage;
                                                            }

                                                            // Final Base URL Prepend karna (uploads folder ke sath)
                                                            med.Image = "https://ecommerencesite.onrender.com/uploads" + cleanImage;
                                                  }
                                                  else
                                                  {
                                                            med.Image = string.Empty;
                                                  }
                                        }

                                        return medicineList;
                              }
                              catch (Exception ex)
                              {
                                        Console.WriteLine("Error: " + ex.Message);
                                        return new List<Medicine>();
                              }
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




