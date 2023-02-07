namespace e07.application.dto;

public class DeveloperModificationDTO // Here we can use inheritance to avoid repeating the properties and use the same validator for main dtos 
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int WorkedHours { get; set; }
    public decimal SalaryByHours { get; set; }
    public int DeveloperTypeId { get; set; }
}