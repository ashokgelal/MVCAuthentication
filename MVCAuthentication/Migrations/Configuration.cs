#region Using

using System;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCAuthentication.Models;

#endregion

namespace MVCAuthentication.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var applicationDbContext = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(applicationDbContext);
            var manager = new UserManager<ApplicationUser>(userStore);

            for (var i = 0; i < 4; i++)
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = string.Format("Email{0}@example.com", i),
                    FirstName = string.Format("FirstName{0}", i),
                    LastName = string.Format("LastName{0}", i),
                    Email = string.Format("Email{0}@example.com", i)
                };
                var succeeded = manager.Create(applicationUser, string.Format("Password{0}", i));
                Trace.TraceInformation("{0} Created? {1}", applicationUser.UserName, succeeded);
            }
        }
    }
}