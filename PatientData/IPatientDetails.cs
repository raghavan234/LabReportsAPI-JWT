using LabReportsAPI.Models;

namespace LabReportsAPI.PatientData
{
    public interface IPatientDetails
    {
        List<Patient> GetPatients();
        Patient GetPatient(Guid id);
        Patient AddPatient(Patient patient);
        void DeletePatient(Patient patient);
        Patient EditPatient(Patient patient);
    }
}
