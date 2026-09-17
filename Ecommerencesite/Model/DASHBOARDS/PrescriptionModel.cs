using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerencesite.Model.DASHBOARDS
{
          //public class PrescriptionModel
          //{
          //          [Key]
          //          public int Id { get; set; }
          //          public int UserId { get; set; }         
          //          public string DoctorName { get; set; }
          //          public string DateIssued { get; set; }
          //          public string PrescriptionUrl { get; set; }
          //}

          public class PrescriptionModel
          {
                    [Key]
                    public int Id { get; set; } // Primary Key for Prescription
                    public string PatientName { get; set; }
                    public string DoctorName { get; set; }
                    public string Diagnosis { get; set; }
                    public DateTime? PrescriptionDate { get; set; } = DateTime.UtcNow;
                    public string Status { get; set; } = "Active";
                    //public List<MedicineDetail> Medicines { get; set; }

                    public List<MedicineDetail> Medicines { get; set; } = new List<MedicineDetail>();
          }

          public class MedicineDetail
          {
                  


                    [Key]
                    public int Id { get; set; }
                   
                    public string MedicineName { get; set; }
                    public string Dosage { get; set; }
                    public string Frequency { get; set; }
          }
}
