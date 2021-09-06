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
    /// Collaborator Model Class
    /// </summary>
    public class CollaboratorModel
    {
        /// <summary>
        /// Gets or sets CollaboratorId
        /// </summary>
        [Key]
        public int CollaboratorId { get; set; }

        /// <summary>
        /// Gets or sets NoteId
        /// </summary>
        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets NotesModel
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        public string SenderMail { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        public string ReceiverMail { get; set; }
    }
}
