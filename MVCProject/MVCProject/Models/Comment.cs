using System;
using System.Collections.Generic;
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
		/// The timestamp for the creation for the post; alternatively the timestamp for the last edit, if any such editing has taken place.
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// The previous version of the post - this should be null if there has been no edits.
		/// </summary>
		public Comment PreviousVersion { get; set; }
		/// <summary>
		/// The author of the post; alternatively the author of the last edit, if any such editing has taken place.
		/// </summary>
		public ApplicationUser Author { get; set; }
		/// <summary>
		/// The BlogEntry or StoreItem to which the comment belongs.
		/// </summary>
		public BlogEntry ParentEntry { get; set; }
	}
}