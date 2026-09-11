using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;
using Ecommerencesite.Model.DASHBOARDS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class DashBoardServicesRepository : IDashBoardServicesRepository         
{
          public  readonly Ecommerecewebstedatabase _context;

          public DashBoardServicesRepository(Ecommerecewebstedatabase context)
          {
                   this._context   = context;
          }

          public DashboardDataModel GetCustomerDashboard(int customerId)
          {
                    // 1. Fetch customer name dynamically
                    var customer = _context.userMediciness
                        .Where(c => c.id == customerId)
                        .Select(c => c.FirstName + " " + c.LastName)
                        .FirstOrDefault();

                    // 2. Fetch cart items using UserId
                    var cartMedicines = _context.cartss
                        .Where(ci => ci.UserId == customerId)
                        .Select(ci => new CartItem
                        {
                                  Name = ci.MedicineId.ToString(),
                                  Price = ci.UnitPrice ?? 0,
                                  Quantity = ci.Quantity
                        })
                        .ToList();

                    // 3. Fetch blood glucose records using lowercase id matching your entity definition
                    var bloodGlucose = _context.BloodGlucoseDatas
       .Where(bg => bg.userid == customerId)
       .OrderByDescending(bg => bg.RecordDate)
       .Take(4)
       .Select(bg => new Ecommerencesite.Model.DASHBOARDS.BloodGlucoseData
       {
                 DayLabel = bg.DayLabel,
                 Value = bg.Value
       })
       .ToList();

                    // 4. Fetch weight progress using lowercase id
                    var weightProgress = _context.WeightProgressDatas
                        .Where(wp => wp.Weight == customerId)
                        .OrderBy(wp => wp.Date)
                        .Select(wp => new WeightProgressData
                        {
                                  Date = wp.Date,
                                  Weight = wp.Weight
                        })
                        .ToList();

                    var bloodPressure = _context.BloodPressureDatas
        .Where(bp => bp.Userid == customerId)
        .GroupBy(bp => bp.Category)
        .Select(g => new Ecommerencesite.Model.DASHBOARDS.BloodPressureData
        {
                  Category = g.Key,
                  Value = g.Count()
        })
        .ToList();

                    return new DashboardDataModel
                    {
                              UserName = customer,
                              BloodGlucose = bloodGlucose,
                              WeightProgress = weightProgress,
                              BloodPressure = bloodPressure,
                              CartMedicines = cartMedicines
                    };
          }
}