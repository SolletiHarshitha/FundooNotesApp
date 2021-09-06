// ----------------------------------------------------------------------------------------------------------
// <copyright file="UserContext.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Context
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    /// User Context Class
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the UserContext class
        /// </summary>
        /// <param name="options">Database Context Options</param>
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the users table
        /// </summary>
        public DbSet<RegisterModel> Users { get; set; }

        /// <summary>
        /// Gets or sets the notes table
        /// </summary>
        public DbSet<NotesModel> Notes { get; set; }

        /// <summary>
        /// Gets or sets the collaborator table
        /// </summary>
        public DbSet<CollaboratorModel> Collaborator { get; set; }

        /// <summary>
        /// Gets or sets the label table
        /// </summary>
        public DbSet<LabelModel> Label { get; set; }
    }
}
