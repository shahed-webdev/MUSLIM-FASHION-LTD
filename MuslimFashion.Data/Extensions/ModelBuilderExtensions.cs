using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MuslimFashion.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedAdminData(this ModelBuilder builder)
        {
            var ADMIN_ID = "A0456563-F978-4135-B563-97F23EA02FDA";
            // any guid, but nothing is against to use the same one
            var ROLE_ID = "5A71C6C4-9488-4BCC-A680-445A34C6E721";
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = UserType.Admin.ToString(),
                    NormalizedName = UserType.Admin.ToString().ToUpper(),
                    ConcurrencyStamp = ROLE_ID
                },
                new IdentityRole
                {
                    Id = "9E6E9812-4A93-4F28-81F3-8B52181EFA77",
                    Name = UserType.SubAdmin.ToString(),
                    NormalizedName = UserType.SubAdmin.ToString().ToUpper(),
                    ConcurrencyStamp = "9E6E9812-4A93-4F28-81F3-8B52181EFA77"
                },
                new IdentityRole
                {
                    Id = "EC8F8D09-01B0-4C83-AF29-733F057BC139",
                    Name = UserType.Customer.ToString(),
                    NormalizedName = UserType.Customer.ToString().ToUpper(),
                    ConcurrencyStamp = "EC8F8D09-01B0-4C83-AF29-733F057BC139"
                }
            );


            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDch3arYEB9dCAudNdsYEpVX7ryywa8f3ZIJSVUmEThAI50pLh9RyEu7NjGJccpOog==",
                SecurityStamp = string.Empty,
                LockoutEnabled = true,
                ConcurrencyStamp = ADMIN_ID
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<Registration>().HasData(new Registration
            {
                RegistrationId = 1,
                UserName = "Admin",
                Type = UserType.Admin,
                Name = "Admin"
            });
        }
    }
}
