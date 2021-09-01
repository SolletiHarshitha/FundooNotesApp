// ----------------------------------------------------------------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Notes Model Class
    /// </summary>
    public class NotesModel
    {
        /// <summary>
        /// Gets or sets the note id
        /// </summary>
        [Key]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Register Model
        /// </summary>
        public virtual RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Gets or sets the title 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the remainder 
        /// </summary>
        public string Remainder { get; set; }

        /// <summary>
        /// Gets or sets the color 
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to archive a note or not
        /// </summary>
        public bool Archive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the note should pin or unpin
        /// </summary>
        public bool Pin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the note should delete or not
        /// </summary>
        public bool Trash { get; set; }
    }
}
