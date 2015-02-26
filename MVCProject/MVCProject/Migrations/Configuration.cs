namespace MVCProject.Migrations
{
	using MVCProject.Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCProject.Models.ApplicationDbContext context)
        {
			context.BlogEntries.AddOrUpdate(
				b => b.Title,
				new BlogEntry("This is a blog post", "Content goes in here, to fill out the post. If there is no content, one usually uses lorem ipsum, which is a sort of \"filler\" text that you use to test element width and such, but I feel like using just normal text atm. It feels a bit less like cheating, and more like you're actually doing something, even if you're not.", "http://lorempixel.com/100/100"),
				new BlogEntry("This is a another blog post", "Content goes in here, to fill out the post. If there is no content, one usually uses lorem ipsum, which is a sort of \"filler\" text that you use to test element width and such, but I feel like using just normal text atm. It feels a bit less like cheating, and more like you're actually doing something, even if you're not.", "http://lorempixel.com/100/100"),
				new BlogEntry("This is a a third blog post", "Content goes in here, to fill out the post. If there is no content, one usually uses lorem ipsum, which is a sort of \"filler\" text that you use to test element width and such, but I feel like using just normal text atm. It feels a bit less like cheating, and more like you're actually doing something, even if you're not.", "http://lorempixel.com/100/100"),
				new BlogEntry("This is a blog post lost in time - made before all others were created", "Content goes in here, to fill out the post. If there is no content, one usually uses lorem ipsum, which is a sort of \"filler\" text that you use to test element width and such, but I feel like using just normal text atm. It feels a bit less like cheating, and more like you're actually doing something, even if you're not.", "http://lorempixel.com/100/100", new DateTime(1961, 3, 12))
				);
        }
    }
}
