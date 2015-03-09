using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace MVCProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		//public DateTime Joined { get; set; }
		public virtual ICollection<BlogEntry> BlogEntries { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }

		public void AddPost(BlogEntry b) {
			if (!this.BlogEntries.Contains(b)) { this.BlogEntries.Add(b); }
			b.Author = this;
		}

		public void AddComment(Comment c) {
			if (!this.Comments.Contains(c)) { this.Comments.Add(c); }
			c.Author = this;
		}

		public void RemovePost(BlogEntry b) {
			if (this.BlogEntries.Contains(b)) { this.BlogEntries.Remove(b); }
		}

		public void RemoveComment(Comment c) {
			if (this.Comments.Contains(c)) { this.Comments.Remove(c); }
			c.Author = this;
		}

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			
			//manager.PasswordValidator = new PasswordValidator {
			//	RequiredLength = 0,
			//	RequireNonLetterOrDigit = false,
			//	RequireDigit = false,
			//	RequireLowercase = false,
			//	RequireUppercase = false,
			//};

			manager.UserLockoutEnabledByDefault = true;
			manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			manager.MaxFailedAccessAttemptsBeforeLockout = 3;

            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

		public System.Data.Entity.DbSet<MVCProject.Models.BlogEntry> BlogEntries { get; set; }
		public System.Data.Entity.DbSet<MVCProject.Models.Comment> Comments { get; set; }
		public System.Data.Entity.DbSet<MVCProject.Models.Tag> Tags { get; set; }
    }
}