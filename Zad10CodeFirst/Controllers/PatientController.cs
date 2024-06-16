using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zad10CodeFirst.Dtos;
using Zad10CodeFirst.Entities;

namespace Zad10CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
  

  

    [HttpGet("{get}")]
    public async Task<IActionResult> GetPatientDetails(int id)
    {
        var dbContext = new PrescriptionDbContext();
        var patient =
            await dbContext.Patients
                .Where(p => p.IdPatient == id)
                .Select(p => new
                {
                    p.IdPatient,
                    p.FirstName,
                    p.LastName,
                    p.BirthDay,
                    Prescriptions = p.Prescriptions
                        .OrderByDescending(pr => pr.DueDate)
                        .Select(pr => new Prescription()
                        {
                            IdPrescription = pr.IdPrescription,
                            Date = pr.Date,
                            DueDate = pr.DueDate,
                            IdDoctor = pr.IdDoctor,
                            PrescriptionMedicaments = pr.PrescriptionMedicaments
                                .Select(pm => new PrescriptionMedicament()
                                {
                                    IdMedicament = pm.IdMedicament,
                                    Dose = pm.Dose,
                                    Details = pm.Details
                                }).ToList()
                        }).ToList()
                }).FirstOrDefaultAsync();

        if (patient == null)
        {
            return NotFound("Patient not found");
        }

        return Ok(patient);
    }
}