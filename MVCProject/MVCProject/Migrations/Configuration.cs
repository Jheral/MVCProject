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
			string filler = "Content goes in here, to fill out the post. If there is no content, one usually uses lorem ipsum, which is a sort of \"filler\" text that you use to test element width and such, but I feel like using just normal text atm. It feels a bit less like cheating, and more like you're actually doing something, even if you're not.";

			BlogEntry b1 = new BlogEntry("This is a blog post", filler, "http://lorempixel.com/100/100");
			BlogEntry b2 = new BlogEntry("This is a another blog post", filler, "http://lorempixel.com/100/100");
			BlogEntry b3 = new BlogEntry("This is a a third blog post", filler, "http://lorempixel.com/100/100");
			BlogEntry b4 = new BlogEntry("This is a blog post lost in time - made before all others were created", filler, "http://lorempixel.com/100/100", new DateTime(1961, 3, 12));

			Tag t1 = new Tag("Stuff", "TAG_STUFF");
			Tag t2 = new Tag("Filler", "TAG_FILLER");
			Tag t3 = new Tag("Time Travel", "TAG_TIMETRAVEL");

			Comment c1 = new Comment("First!", "I beat you all to it, suckers!");
			Comment c2 = new Comment("First sucks!", "Come on! Don't be an asshole and just post \"First\" just to get in there");
			Comment c3 = new Comment("Seriously?", "You don't need to do this kind of shit - at least try to keep it civil, guys.");
			Comment c4 = new Comment("Comment Titles", "Do you really need to use a comment title?");
			Comment c5 = new Comment("", "Nope - it's completely optional (and should be implemented as such, Elias!)");
			Comment c6 = new Comment("", "How the hell did you manage to post something here before the Internet even existed?");
			Comment c7 = new Comment("Beyond First!", "I am the master of time itself! No matter how you try, you can never post before me!",  new DateTime(1886, 11, 5));

			b1.AddComment(c1);
			b1.AddComment(c2);
			b1.AddComment(c3);
			b1.AddTag(t1);

			b2.AddTag(t1);
			b2.AddTag(t2);
			b2.AddComment(c4);
			b2.AddComment(c5);

			b3.AddTag(t2);

			b4.AddTag(t3);
			b4.AddComment(c6);
			b4.AddComment(c7);

			context.Tags.AddOrUpdate(t1, t2, t3);
			context.Comments.AddOrUpdate(c1, c2, c3, c4, c5, c6, c7);
			context.BlogEntries.AddOrUpdate(b1, b2, b3, b4);
        }
    }
}
