using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models {
	[Table("Tags")] // The table this class will be added to
	public class Tag {
		/// <summary>
		/// The primary key of this class' database table, and the unique identifier for the class' objects
		/// </summary>
		[Key]
		public int Id { get; set; }
		/// <summary>
		/// The display name of the tag
		/// </summary>
		public String Display { get; set; }
		/// <summary>
		/// The internal ID of the tag
		/// </summary>
		public String InternalName { get; set; }
		/// <summary>
		/// A list of blog posts that have this tag
		/// </summary>
		public virtual ICollection<BlogEntry> BlogEntries { get; set; }
	}
}