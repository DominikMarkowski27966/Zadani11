using System.Collections;
using Microsoft.AspNetCore.Identity;

namespace Zad10CodeFirst.Entities;

public class Patient : IdentityUser
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}