using LabReportsAPI.Models;
using LabReportsAPI.PatientData;

namespace LabReportsAPI.PatientData
{
    public class MockLabTestDetails : ILabTestDetails
    {
        private IPatientDetails _patient;
        public MockLabTestDetails(IPatientDetails patient)
        {
            _patient = patient;
        }
        private List<LabTest> labTests = new List<LabTest>()
        {
            new LabTest()
            {
                Id = Guid.NewGuid(),
                patientID = "1",
                patientName="Max Aarons",
                Type="Covid-19",
                Result = "Positive",
                EnteredTime = Convert.ToDateTime("30/08/2021"),
                TimeOfTest = Convert.ToDateTime("29/08/2021")
            },
            new LabTest()
            {
                Id = Guid.NewGuid(),
                patientID = "2",
                patientName="Mikel Arteta",
                Type="SARS-V2",
                Result = "Positive",
                EnteredTime = Convert.ToDateTime("12/07/2020"),
                TimeOfTest = Convert.ToDateTime("11/07/2020")
            },
            new LabTest()
            {
                Id = Guid.NewGuid(),
                patientID = "3",
                patientName="Granit Xhaka",
                Type="Omicron-1",
                Result = "Negative",
                EnteredTime = Convert.ToDateTime("19/04/2021"),
                TimeOfTest = Convert.ToDateTime("18/04/2021")
            }
        };

        public LabTest AddLabTest(LabTest labtest)
        {
            labtest.Id = Guid.NewGuid();
            labTests.Add(labtest);
            return labtest;
        }

        public void DeleteLabTest(LabTest labtest)
        {
            labTests.Remove(labtest);
        }

        public LabTest EditLabTest(LabTest labtest)
        {
            var existingLabTest = GetLabTest(labtest.Id);
            existingLabTest.Type = labtest.Type;
            return existingLabTest;
        }

        public LabTest GetLabTest(Guid id)
        {
            return labTests.SingleOrDefault(x => x.Id == id);
        }

        public List<LabTest> GetLabTests()
        {
            return labTests;
        }

        public List<PatientLabTest> GetPatientLabTestDetails()
        {
            var results = (from l in labTests
                           join p in _patient.GetPatients()
                           on l.patientID equals p.patientID
                           select new PatientLabTest
                               {
                                   Name = p.Name,
                                   Gender = p.Gender,
                                   Age = p.Age,
                                   DOB = p.DOB,
                                   Type = l.Type,
                                   Result = l.Result,
                                   EnteredTime = l.EnteredTime,
                                   TimeOfTest = l.TimeOfTest
                               }
                           ).ToList();
            return results;

        }
        public List<PatientLabTest> GetPatientLabTestDetailsByTime(DateTime FromDate, DateTime ToDate)
        {
            var results = (from l in labTests
                           join p in _patient.GetPatients()
                           on l.patientID equals p.patientID
                           where l.TimeOfTest >= FromDate && l.TimeOfTest <= ToDate
                           select new PatientLabTest
                           {
                               Name = p.Name,
                               Gender = p.Gender,
                               Age = p.Age,
                               DOB = p.DOB,
                               Type = l.Type,
                               Result = l.Result,
                               EnteredTime = l.EnteredTime,
                               TimeOfTest = l.TimeOfTest
                           }).ToList();
            return results;

        }

    }
}
