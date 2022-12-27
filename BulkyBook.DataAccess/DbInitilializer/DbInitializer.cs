using BulkyBook.DataAccess.DbInitilializer;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.DbInitilializer
{
    public class DbInitializer:IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                _db.Database.EnsureCreated();
                var migrations = _db.Database.GetPendingMigrations();
                if (migrations.Any())
                    _db.Database.Migrate();
            }
            catch (Exception)
            {

            }

            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Comp)).GetAwaiter().GetResult();

                //if roles are not created, then we will create admin user as well

                var user = new ApplicationUser
                {
                    UserName = "b191210559@sakarya.edu.tr",
                    Email = "b191210559@sakarya.edu.tr",
                    Name = "Seidy Kante",
                    PhoneNumber = "05340000000",
                    StreetAddress = "Arifiye",
                    State = "Adapazarı",
                    PostalCode = "54580",
                    City = "Sakarya"
                };
                var password = "sau";

                _userManager.CreateAsync(user, password).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

                _db.SaveChanges();

            }

            return;
        }
    }
}