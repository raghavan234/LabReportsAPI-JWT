using LabReportsAPI.Models;

namespace LabReportsAPI.PatientData
{
    public interface ILabTestDetails
    {
        List<LabTest> GetLabTests();
        LabTest GetLabTest(Guid id);
        LabTest AddLabTest(LabTest labtest);
        void DeleteLabTest(LabTest labtest);
        LabTest EditLabTest(LabTest labtest);
        List<PatientLabTest> GetPatientLabTestDetails();
        List<PatientLabTest> GetPatientLabTestDetailsByTime(DateTime FromDate, DateTime ToDate);
    }
}
