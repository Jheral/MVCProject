using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models {
	[Table("Comments")] // The table this class will be added to
	public class Comment {
		/// <summary>
		/// The primary key of this class' database table, and the unique identifier for the class' objects
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// The display name and title of the comment
		/// </summary>
		public String Title { get; set; }
		/// <summary>
		/// The content and/or description of the comment
		/// </summary>
		public String Content { get; set; }
		/// <summary>
		/// The handle of the author
		/// </summary>
		public String AuthorName { get; set; }

		/// <summary>
		/// The timestamp for the creation for the post; alternatively the timestamp for the last edit, if any such editing has taken place.
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// The previous version of the post - this should be null if there has been no edits.
		/// </summary>
		public virtual Comment PreviousVersion { get; set; }
		/// <summary>
		/// The author of the post; alternatively the author of the last edit, if any such editing has taken place.
		/// </summary>
		public virtual ApplicationUser Author { get; set; }
		/// <summary>
		/// The BlogEntry or StoreItem to which the comment belongs.
		/// </summary>
		public virtual BlogEntry ParentEntry { get; set; }
		
		public Comment() {
		}

		/// <summary>
		/// "Normal" Constructor
		/// </summary>
		/// <param name="title">Comment's Title</param>
		/// <param name="content">Comment's Content</param>
		public Comment(string title, string content) {
			this.Title = title;
			this.Content = content;
			this.Created = DateTime.Now;
		}

		/// <summary>
		/// "Retroactive" Constructor - use this to create comments for specific dates
		/// </summary>
		/// <param name="title">Comment's Title</param>
		/// <param name="content">Comment's Content</param>
		/// <param name="created">The intended timestamp for the comment</param>
		public Comment(string title, string content, DateTime created, ApplicationUser author = null)
			: this(title, content) {
				this.Created = created;
				if (author != null) {
					this.Author = author;
					this.AuthorName = author.UserName;
				} else {
					this.AuthorName = "Anonymous";
				}
		}

		/// <summary>
		/// "Edit" Constructor - use this to edit a comment
		/// </summary>
		/// <param name="title">Comment's Title</param>
		/// <param name="content">Comment's Content</param>
		/// <param name="previous">The "current" comment, that is to be stored</param>
		public Comment(string title, string content, Comment previous, ApplicationUser author)
			: this(title, content, DateTime.Now, author) {
				this.PreviousVersion = previous;
		}
	}
}