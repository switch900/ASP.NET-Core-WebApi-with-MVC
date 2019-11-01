using Microsoft.AspNetCore.Identity;

namespace BookClient.Data
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager)
        {
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("user1").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "a@a.com",
                    Email = "a@a.com"
                };

                IdentityResult result = userManager.CreateAsync
                (user, "P@$$w0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"NormalUser").Wait();
                } 
            }         
        }
    }
}

