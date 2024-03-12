using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement_Client.DtoModel
{
	public class UserDTO
	{
        public long Id { get; set; }

        [Required]
        public string? Forename { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Date of Birth must be in format YYYYMMDD which is  8 digits")]
        public string DateOfBirth { get; set; }

        public bool IsActive { get; set; }
    }
}

