using LabReportsAPI.Models;

namespace LabReportsAPI.PatientData
{
    public class MockPatientDetails : IPatientDetails
    {
        private List<Patient> patients = new List<Patient>()
        {
            new Patient()
            {
                Id = Guid.NewGuid(),
                patientID = "1",
                Name="Max Aarons",
                Gender = "Male",
                Age =22,
                DOB = Convert.ToDateTime("24/01/1999")
            },
            new Patient()
            {
                Id = Guid.NewGuid(),
                patientID = "2",
                Name="Mikel Arteta",
                Gender = "Male",
                Age =32,
                DOB = Convert.ToDateTime("14/05/1989")
            },
              new Patient()
            {
                Id = Guid.NewGuid(),
                patientID="3",
                Name="Granit Xhaka",
                Gender = "Female",
                Age =36,
                DOB = Convert.ToDateTime("18/09/1985")
            }
        };
        public Patient AddPatient(Patient patient)
        {
            patient.Id=Guid.NewGuid();
            patients.Add(patient);
            return patient;
        }

        public void DeletePatient(Patient patient)
        {
            patients.Remove(patient);
        }

        public Patient EditPatient(Patient patient)
        {
            var existingPatient = GetPatient(patient.Id);
            existingPatient.Name = patient.Name;
            return existingPatient;
        }

        public Patient GetPatient(Guid id)
        {
            return patients.SingleOrDefault(x => x.Id == id);
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }
    }
}
