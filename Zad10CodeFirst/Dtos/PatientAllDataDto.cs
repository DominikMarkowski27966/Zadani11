using Zad10CodeFirst.Entities;

namespace Zad10CodeFirst.ModelsDTO;

public class PatientAllDataDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public virtual List<Prescription> Prescriptions { get; set; }
    
}