using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}