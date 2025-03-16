using Microsoft.AspNetCore.Identity;
using personal_website.Server.Areas.Identity.Data;

namespace personal_website.Server.Data
{
    public class PersonalWebsiteSeedDataContext
    {
        public static async Task SeedUserAndRoleAsync(UserManager<PersonalUser> userManager)
        {



            if (!userManager.Users.Any())
            {
                var users = new List<(PersonalUser User, string Password)>
                {
                    (new PersonalUser
                    {
                        UserName = "meow@meow.com",
                        Email = "meow@meow.com",
                        DisplayName = "Admin Meow User",
                        Location = "Random Places",
                        Website = "randomwebsite.com",
                        GithubUsername = "Random Admin User",
                        Timezone = "PT",
                        EmailConfirmed = true
                    }, "Meow123!"
                    )
                };

                foreach ( var (user, password) in users )
                {
                    var result = await userManager.CreateAsync(user, password);
                    if ( !result.Succeeded )
                    {
                        throw new Exception($"Failed to seed user");
                    }
                }
            }
        }
    }
}
