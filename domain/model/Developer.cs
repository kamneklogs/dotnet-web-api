using System.ComponentModel.DataAnnotations;

namespace e07.domain.model;
public class Developer
{
    [Key]
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public int WorkedHours { get; set; }
    public decimal SalaryByHours { get; set; }
    public DeveloperType DeveloperType { get; set; }
}