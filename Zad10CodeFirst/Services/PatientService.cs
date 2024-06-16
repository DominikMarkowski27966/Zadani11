using Microsoft.EntityFrameworkCore;
using Zad10CodeFirst.Entities;
using Zad10CodeFirst.ModelsDTO;

namespace Zad10CodeFirst.Services;

public class PatientService : IPatientService
{
    private PrescriptionDbContext _context;

    public PatientService(PrescriptionDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<PatientAllDataDto> GetPatientData(int id)
    {
        if (await DoesClientExists(id))
        {
            return null!;
        }
        
        return null;
    }

    private async Task<bool> DoesClientExists(int id)
    {
        var res = await _context
            .Patients
            .Where(p => p.IdPatient == id)
            .FirstOrDefaultAsync();

        return res == null;
    }
}