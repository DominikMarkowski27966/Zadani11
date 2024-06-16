using Zad10CodeFirst.Entities;
using Zad10CodeFirst.ModelsDTO;

namespace Zad10CodeFirst.Services;

public interface IPatientService
{
    public Task<PatientAllDataDto> GetPatientData(int id);
}