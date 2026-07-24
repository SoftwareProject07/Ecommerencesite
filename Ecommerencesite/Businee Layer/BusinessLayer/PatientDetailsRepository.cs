using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Ecommerencesite.Model;

namespace Ecommerencesite.Businee_Layer.BusinessLayer
{
          public class PatientDetailsRepository : IPatientDetailsRepository
          {
                    private readonly Ecommerecewebstedatabase _context;


                              public PatientDetailsRepository(Ecommerecewebstedatabase context)
                    {
                              this._context = context;

                    }
                    public void AddDoctorAssigntoPatient(DoctorAssigntoPatientMOdel adddoctorAssigntoPatientMOdel)
                    {
                          _context.doctorAssigntoPatientMOdels.Add(adddoctorAssigntoPatientMOdel);
                              _context.SaveChanges();
                    }

                    public void AddPatientDetails(PatientDetailsModel patientDetailsModel)
                    {
                            _context.patientDetailsModels.Add(patientDetailsModel);
                              _context.SaveChanges();
                    }

                    public List<DoctorAssigntoPatientMOdel> AllDoctorAssigntoPatient()
                    {
                            var listdoctorAssigntoPatient = _context.doctorAssigntoPatientMOdels.ToList();    
                              return listdoctorAssigntoPatient;
                    }

                    public List<PatientDetailsModel> AllPatientDetails()
                    {
                             var listpatientDetails = _context.patientDetailsModels.ToList();
                              return listpatientDetails;    
                    }

                    public DoctorAssigntoPatientMOdel DeleteDoctorAssigntoPatient(int id)
                    {
                              var doctorAssigntoPatient = _context.doctorAssigntoPatientMOdels.Where(s=>s.DoctorAssigntoPatientod==id).FirstOrDefault();
                              if (doctorAssigntoPatient != null)
                              {
                                        _context.doctorAssigntoPatientMOdels.Remove(doctorAssigntoPatient);
                                        _context.SaveChanges();
                              }
                              return doctorAssigntoPatient;
                    }

                    public PatientDetailsModel DeletePatientDetails(int id)
                    {
                              var patientDetails = _context.patientDetailsModels.Where(s=>s.patientDetailsId==id).FirstOrDefault();
                              if (patientDetails != null)
                              {
                                        _context.patientDetailsModels.Remove(patientDetails);
                                        _context.SaveChanges();
                              }
                              return patientDetails;
                    }

                    public DoctorAssigntoPatientMOdel GetDoctorAssigntoPatientById(int id)
                    {

                              var doctorAssigntoPatient = _context.doctorAssigntoPatientMOdels.Find(id);
                              return doctorAssigntoPatient;
                    }

                    public PatientDetailsModel GetPatientDetailsById(int id)
                    {
                             var patientDetails = _context.patientDetailsModels.Find(id);
                              return patientDetails;
                    }

                    public void UpdateDoctorAssigntoPatient(DoctorAssigntoPatientMOdel updatedoctorAssigntoPatientMOdel)
                    {
                             _context.doctorAssigntoPatientMOdels.Update(updatedoctorAssigntoPatientMOdel);
                              _context.SaveChanges();
                    }

                    public void UpdatePatientDetails(PatientDetailsModel updatepatientDetailsModel)
                    {
                             _context.patientDetailsModels.Update(updatepatientDetailsModel);
                              _context.SaveChanges();
                    }
          }
}
