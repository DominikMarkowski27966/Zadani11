using Zad10CodeFirst.Entities;

namespace Zad10CodeFirst.ModelsDTO;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public virtual List<MedicamentDto> MedicamentDtos { get; set; }
    public DoctorDto DoctorDto { get; set; }
}