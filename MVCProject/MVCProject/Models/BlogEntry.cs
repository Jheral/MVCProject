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

		public BlogEntry() {
			this.Tags = new HashSet<Tag>();
			this.Comments = new HashSet<Comment>();
		}

		public BlogEntry(string title, string content, string thumbnail)
			: this() {
				this.Title = title;
				this.Content = content;
				this.Thumbnail = thumbnail;
				this.Created = DateTime.Now;
		}

		public BlogEntry(string title, string content, string thumbnail, DateTime created)
			: this(title, content, thumbnail) {
				this.Created = created;
		}

		public BlogEntry(string title, string content, string thumbnail, BlogEntry previous)
			: this(title, content, thumbnail) {
				this.PreviousVersion = previous;
		}
	}
}