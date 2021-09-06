// ----------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Collaborator Model class
    /// </summary>
    public class CollaboratorModel
    {
        /// <summary>
        /// Gets or sets the collaborator id
        /// </summary>
        [Key]
        public int CollaboratorId { get; set; }

        /// <summary>
        /// Gets or sets the note id
        /// </summary>
        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets the notes model
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets the sender mail
        /// </summary>
        public string SenderMail { get; set; }

        /// <summary>
        /// Gets or sets the receiver mail
        /// </summary>
        public string ReceiverMail { get; set; }
    }
}
