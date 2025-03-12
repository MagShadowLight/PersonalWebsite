using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace personal_website.Server.Areas.Identity.Data;

// Add profile data for application users by adding properties to the PersonalUser class
public class PersonalUser : IdentityUser
{
    public string? DisplayName { get; set; }
    public string? Location { get; set; }
    public string? Website { get; set; }
    public string? GithubUsername { get; set; }
    public string? Timezone { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}

