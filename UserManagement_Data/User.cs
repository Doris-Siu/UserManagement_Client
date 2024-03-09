using System.ComponentModel.DataAnnotations;

namespace UserManagement_Data;

public class User
{
    [Key]
    public long Id { get; set; }
    public string? Forename { get; set; }
    public string? Surname { get; set; }
    public string? DateOfBirth { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
}
