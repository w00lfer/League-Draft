using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using LeagueDraft_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueDraft_API.AppConfiguration
{
    public class DbInitializer
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public DbInitializer(AppDbContext appDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            await _appDbContext.Database.MigrateAsync();
            await SeedRoles();
            await SeedUsers();
        }

        public async Task SeedRoles()
        {
            if (!_roleManager.Roles.Any())
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
        }
        public async Task SeedUsers()
        {
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new IdentityUser { UserName = "userone", Email = "userone@test.com", PhoneNumber = "123123123" }, "UserOne123!");
                await _userManager.CreateAsync(new IdentityUser { UserName = "usertwo", Email = "usertwo@test.com", PhoneNumber = "999333999"}, "UserTwo123!");

                var admin = new IdentityUser { UserName = "Admin", Email = "admin@test.com", PhoneNumber = "555555555" };
                await _userManager.CreateAsync(admin, "Admin123!");
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
