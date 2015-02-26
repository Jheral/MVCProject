using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models {
	[Table("BlogEntries")] // The table this class will be added to
	public class BlogEntry {
		/// <summary>
		/// The primary key of this class' database table, and the unique identifier for the class' objects
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// The display name and title of the post
		/// </summary>
		public String Title { get; set; }
		/// <summary>
		/// The content and/or description of the post
		/// </summary>
		public String Content { get; set; }
		/// <summary>
		/// The URL to the thumbnail that is to be used for this post
		/// </summary>
		public String Thumbnail { get; set; }

		/// <summary>
		/// The timestamp for the creation for the post; alternatively the timestamp for the last edit, if any such editing has taken place.
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// The previous version of the post - this should be null if there has been no edits.
		/// </summary>
		public BlogEntry PreviousVersion { get; set; }
		/// <summary>
		/// The author of the post; alternatively the author of the last edit, if any such editing has taken place.
		/// </summary>
		public ApplicationUser Author { get; set; }
		/// <summary>
		/// A collection of posts that relate to the post
		/// </summary>
		public virtual ICollection<Tag> Tags { get; set; }
		/// <summary>
		/// A collection of comments that relate to the post
		/// </summary>
		public virtual ICollection<Comment> Comments { get; set; }

		/// <summary>
		/// Initialization of Tag and Comment Collections
		/// </summary>
		private BlogEntry() {
			this.Tags = new HashSet<Tag>();
			this.Comments = new HashSet<Comment>();
		}

		/// <summary>
		/// "Normal" Constructor
		/// </summary>
		/// <param name="title">The title of the entry</param>
		/// <param name="content">The content of the entry</param>
		/// <param name="thumbnail">The URL to the entry's thumbnail</param>
		public BlogEntry(string title, string content, string thumbnail)
			: this() {
				this.Title = title;
				this.Content = content;
				this.Thumbnail = thumbnail;
				this.Created = DateTime.Now;
		}

		/// <summary>
		/// Constructor to use while making a post with a specific timestamp, rather than using DateTime.Now.
		/// </summary>
		/// <param name="title">The title of the entry</param>
		/// <param name="content">The content of the entry</param>
		/// <param name="thumbnail">The URL to the entry's thumbnail</param>
		/// <param name="created">DateTime object for the time of creation</param>
		public BlogEntry(string title, string content, string thumbnail, DateTime created)
			: this(title, content, thumbnail) {
				this.Created = created;
		}

		/// <summary>
		/// Constructor to use while editing a post - creates a new blog entry and stores the old one in it.
		/// </summary>
		/// <param name="title">The title of the entry</param>
		/// <param name="content">The content of the entry</param>
		/// <param name="thumbnail">The URL to the entry's thumbnail</param>
		/// <param name="previous">The previous entry, to be stored for version history purposes</param>
		public BlogEntry(string title, string content, string thumbnail, BlogEntry previous)
			: this(title, content, thumbnail) {
				this.PreviousVersion = previous;
		}

		/// <summary>
		/// Adds a comment to the blog entry
		/// </summary>
		/// <param name="c">Comment to add</param>
		public void AddComment(Comment c) {
			if (!this.Comments.Contains(c)) { this.Comments.Add(c); }
		}

		/// <summary>
		/// Removes a comment from the blog entry
		/// </summary>
		/// <param name="c">Comment to remove</param>
		public void RemoveComment(Comment c) {
			if (this.Comments.Contains(c)) { this.Comments.Remove(c); }
		}

		/// <summary>
		/// Adds a tag to the blog entry, and adds the blog entry to the tag's list
		/// </summary>
		/// <param name="t">Tag to add</param>
		public void AddTag(Tag t) {
			if (!this.Tags.Contains(t)) { this.Tags.Add(t); }
			if (!t.BlogEntries.Contains(this)) { t.BlogEntries.Add(this); }
		}

		/// <summary>
		/// Removes a tag from the blog entry, and removes the blog entry from the tag's list
		/// </summary>
		/// <param name="t">Tag to remove</param>
		public void RemoveTag(Tag t) {
			if (this.Tags.Contains(t)) { this.Tags.Remove(t); }
			if (t.BlogEntries.Contains(this)) { t.BlogEntries.Remove(this); }
		}
	}
}