using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    IList<Result>? Results { get; set; }
}
