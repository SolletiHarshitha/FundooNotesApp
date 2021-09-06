// ----------------------------------------------------------------------------------------------------------
// <copyright file="LabelModel.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// LabelModel class
    /// </summary>
    public class LabelModel
    {
        /// <summary>
        /// Gets or sets label id
        /// </summary>
        [Key]
        public int LabelId { get; set; }

        /// <summary>
        /// Gets or sets label name
        /// </summary>
        [Required]
        public string LabelName { get; set; }

        /// <summary>
        /// Gets or sets note id
        /// </summary>
        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets notes model
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets user id
        /// </summary>
        [ForeignKey("RegisterModel")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets register model
        /// </summary>
        public virtual RegisterModel RegisterModel { get; set; }
    }
}
