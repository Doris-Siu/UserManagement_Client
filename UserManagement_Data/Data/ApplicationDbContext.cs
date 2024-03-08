//implement DB later

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement_Data;

namespace UserManagement_Data.Data
{
    public class ApplicationDbContext 
    {
        public ApplicationDbContext()
            
        {
        }
        public DbSet<User> Users { get; set; }
    }
    


}

