using Zad10CodeFirst.Entities;

namespace Zad10CodeFirst.Services;

public interface PatientService
{
    public Task<Patient> GetPatientData(int id);
}