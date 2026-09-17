using System.ComponentModel.DataAnnotations;

namespace Ecommerencesite.Model.LABTESTMODEL
{
          public class BookingRequestModel
          {
                    [Key]
                    public int TestId { get; set; }
                    public string TestType { get; set; } // Home Collection / Lab Visit
                    public string PatientName { get; set; }
                    public int Age { get; set; }
                    public string Gender { get; set; }
                    public string MobileNumber { get; set; }
                    public string Address { get; set; }
                    public string Pincode { get; set; }
                    public double DistanceInKm { get; set; } // Calculated distance from lab
                    public DateTime AppointmentDate { get; set; }
                    public string TimeSlot { get; set; }
          }
}
