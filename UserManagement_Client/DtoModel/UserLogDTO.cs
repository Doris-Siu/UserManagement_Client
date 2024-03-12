using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement_Client.DtoModel
{
	public class UserLogDTO
	{
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string? LogLevel { get; set; }
        public string? Message { get; set; }
        public DateTime? LogDateTime { get; set; }
    }
}

