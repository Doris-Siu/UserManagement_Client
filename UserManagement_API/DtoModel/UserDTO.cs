using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement_API.DtoModel
{
	public class UserDTO
	{
        public long Id { get; set; }

        [Required]
        public string? Forename { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        public string? DateOfBirth { get; set; }

        [Required]
        public string? Email { get; set; }

        public bool IsActive { get; set; }
    }
}

