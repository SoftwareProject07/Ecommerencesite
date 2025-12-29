using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;


//DateTime expiryDateParsed;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{

          public class MedicineRepository : IMedicineRepositort
          {
                    private readonly Ecommerecewebstedatabase dbcontext;
                    private readonly IWebHostEnvironment _env;

                    public MedicineRepository(Ecommerecewebstedatabase _dbcontext, IWebHostEnvironment env)
                    {
                              this.dbcontext = _dbcontext;
                              _env = env;

                    }

                    //[HttpPost("CreateMedicine")]
                    //public ResponseModel CreateMedicine(Medicine createMedicine)
                    //{
                    //          if (createMedicine.ExpiryDate.HasValue)
                    //          {
                    //                    createMedicine.ExpiryDate =
                    //                        DateTime.SpecifyKind(createMedicine.ExpiryDate.Value, DateTimeKind.Utc);
                    //          }

                    //          createMedicine.STATUS = 1;

                    //          dbcontext.medicinesss.Add(createMedicine);
                    //          dbcontext.SaveChanges();

                    //          return new ResponseModel
                    //          {
                    //                    status = true,
                    //                    responseMessage = "Medicine Create successfully",
                    //                    medicine = createMedicine
                    //          };
                    //}

                    public async Task<bool> CreateMedicineAsync(Medicine medicine, IFormFile image)
                    {
                              try
                              {
                                        // ✅ 1️⃣ Validation
                                        if (medicine == null)
                                                  throw new Exception("Medicine data is null");

                                        if (image == null || image.Length == 0)
                                                  throw new Exception("Image is null or empty");

                                        // ✅ 2️⃣ WebRootPath safety
                                        var webRoot = _env.WebRootPath;

                                        if (string.IsNullOrEmpty(webRoot))
                                                  throw new Exception("WebRootPath is null. Check wwwroot & UseStaticFiles");

                                        // ✅ 3️⃣ Folder path
                                        string folderPath = Path.Combine(webRoot, "uploads", "medicines");

                                        if (!Directory.Exists(folderPath))
                                                  Directory.CreateDirectory(folderPath);

                                        // ✅ 4️⃣ Unique file name
                                        string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                                        string filePath = Path.Combine(folderPath, fileName);

                                        // ✅ 5️⃣ Save image
                                        using (var stream = new FileStream(filePath, FileMode.Create))
                                        {
                                                  await image.CopyToAsync(stream);
                                        }

                                        // ✅ 6️⃣ Save image path in DB (PROPERTY NAME CHECK)
                                        medicine.IMAGEURL = "/uploads/medicines/" + fileName;
                                        //  medicine.CreatedDate = DateTime.Now;

                                        // ✅ 7️⃣ DbSet NAME CHECK
                                        dbcontext.medicinesss.Add(medicine);
                                        await dbcontext.SaveChangesAsync();

                                        return true;
                              }
                              catch (Exception ex)
                              {
                                        // 🔥 IMPORTANT: log this during debug
                                        Console.WriteLine(ex.Message);
                                        throw; // ❗ temporarily throw to SEE real error
                              }
                    }

                    //public async Task<bool> CreateMedicineAsync(Medicine medicine, IFormFile image)
                    //{
                    //          try
                    //          {
                    //                    // ✅ 1️⃣ Validation
                    //                    if (medicine == null)
                    //                              throw new Exception("Medicine data is null");

                    //                    if (image == null || image.Length == 0)
                    //                              throw new Exception("Image is null or empty");

                    //                    // ✅ 2️⃣ Parse ExpiryDate (dd/MM/yyyy → DateTime)
                    //                    DateTime expiryDateParsed; // ✅ DECLARED

                    //                    if (!DateTime.TryParseExact(
                    //                            medicine.ExpiryDate,              // string
                    //                            "dd/MM/yyyy",
                    //                            CultureInfo.InvariantCulture,
                    //                            DateTimeStyles.None,
                    //                            out expiryDateParsed))
                    //                    {
                    //                              throw new Exception("Invalid ExpiryDate format. Use dd/MM/yyyy");
                    //                    }

                    //                    // ✅ 3️⃣ WebRootPath
                    //                    var webRoot = _env.WebRootPath;
                    //                    if (string.IsNullOrEmpty(webRoot))
                    //                              throw new Exception("WebRootPath is null. Check wwwroot & UseStaticFiles");

                    //                    // ✅ 4️⃣ Folder
                    //                    string folderPath = Path.Combine(webRoot, "uploads", "medicines");
                    //                    if (!Directory.Exists(folderPath))
                    //                              Directory.CreateDirectory(folderPath);

                    //                    // ✅ 5️⃣ Image save
                    //                    string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                    //                    string filePath = Path.Combine(folderPath, fileName);

                    //                    using (var stream = new FileStream(filePath, FileMode.Create))
                    //                    {
                    //                              await image.CopyToAsync(stream);
                    //                    }

                    //                    // ✅ 6️⃣ Create DB Entity
                    //                    var medicineEntity = new Medicine
                    //                    {
                    //                              Name = medicine.Name,
                    //                              Manufacturer = medicine.Manufacturer,
                    //                              UnitPrice = medicine.UnitPrice,
                    //                              Discount = medicine.Discount,
                    //                              Quantity = medicine.Quantity,
                    //                              ExpiryDate = medicine.ExpiryDate, // ✅ DateTime
                    //                              IMAGEURL = "/uploads/medicines/" + fileName,
                    //                              STATUS = medicine.STATUS,
                    //                              // CreatedDate = DateTime.Now
                    //                    };

                    //                    // ✅ 7️⃣ Save to DB
                    //                    dbcontext.medicinesss.Add(medicineEntity);
                    //                    await dbcontext.SaveChangesAsync();

                    //                    return true;
                    //          }
                    //          catch (Exception ex)
                    //          {
                    //                    Console.WriteLine("CreateMedicine Error: " + ex.Message);
                    //                    throw; // DEBUG MODE
                    //          }
                    //}


               



                    public ResponseModel DeleteMedicine(int id)
                    {
                              var medicine = dbcontext.medicinesss.FirstOrDefault(x => x.id == id);

                              if (medicine == null)
                              {
                                        return new ResponseModel
                                        {
                                                  status = false,
                                                  responseMessage = "Medicine not found"
                                        };
                              }

                              // ✅ SOFT DELETE
                              medicine.STATUS = 0;
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

                    public List<Medicine> lstmedicine()
                    {
                              try
                              {
                                        return dbcontext.medicinesss
                                                       .Where(x => x.STATUS == 1).OrderBy(x => x.id)
                                                       .ToList();
                                       // return Ok(new { status = true, data });

                              }
                              catch
                              {
                                        return new List<Medicine>(); // ❗ NEVER throw 500
                              }
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

                              medicine.Name = updatemedicine.Name;
                              medicine.Manufacturer = updatemedicine.Manufacturer;
                              medicine.UnitPrice = updatemedicine.UnitPrice;
                              medicine.Discount = updatemedicine.Discount;
                              medicine.Quantity = updatemedicine.Quantity;
                              medicine.ExpiryDate = updatemedicine.ExpiryDate;
                              medicine.STATUS = 1;

                              dbcontext.SaveChanges();

                              return new ResponseModel
                              {
                                        status = true,
                                        responseMessage = "Medicine Updated Successfully",
                                        medicine = medicine
                              };
                    }

          }


}

