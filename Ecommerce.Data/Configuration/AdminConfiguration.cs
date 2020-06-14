using Ecommerce.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ecommerce.Data.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<AppUser>
    {
        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

        public void Configure(EntityTypeBuilder<AppUser> builder) {
            var admin = new AppUser {
                Id = adminId,
                UserName = "test",
                NormalizedUserName = "TESTADMIN",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                PhoneNumber = "5567778899",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
            };

            admin.PasswordHash = PassGenerate(admin);

            builder.HasData(admin);
        }

        public string PassGenerate(AppUser user) {
            var passHash = new PasswordHasher<AppUser>();
            return passHash.HashPassword(user, "test");
        }
    }
}
