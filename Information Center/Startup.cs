using Information_Center.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Information_Center.Startup))]
namespace Information_Center
{
    public partial class Startup
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }
        public void CreateDefaultRolesAndUsers()
        {
            //RoleStore manager allow us to manage roles && save it in db via rolestore class
            //this to manage roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));
            //this to manage users
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.Name = "عمدة الكينج";
                user.UserName = "mohamed.admin2@gmail.com";
                user.Email = "mohamed.admin2@gmail.com";
                user.UserType = "Admins";
                var check = userManager.Create(user, "Kh@l!123");
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, user.UserType);
                }
            }
            if (!roleManager.RoleExists("Student"))
            {
                var studentRole = new IdentityRole();
                studentRole.Name = "Student";
                roleManager.Create(studentRole);
            }
            if (!roleManager.RoleExists("Instructor"))
            {
                var InstructorRole = new IdentityRole();
                InstructorRole.Name = "Instructor";
                roleManager.Create(InstructorRole);
            }


        }
    }
}
