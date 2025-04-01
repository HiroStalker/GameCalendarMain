using Microsoft.AspNetCore.Identity;

namespace ProyectoFFXIV.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; } = false;
    }
}