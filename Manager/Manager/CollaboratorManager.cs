// ----------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Manager
{
    using System.Collections.Generic;
    using global::Manager.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// CollaboratorManager class
    /// </summary>
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// Object for ICollaborator Repository
        /// </summary>
        private readonly ICollaboratorRepository repository;

        /// <summary>
        /// Initializes a new instance of the CollaboratorManager class
        /// </summary>
        /// <param name="repository">The Parameter</param>
        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Add Collaborator Method
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Result of the boolean method</returns>
        public bool AddCollaborator(CollaboratorModel collaborator)
        {
            return this.repository.AddCollaborator(collaborator);
        }

        /// <summary>
        /// Get collaborator Method
        /// </summary>
        /// <param name="noteId">The Parameter</param>
        /// <returns>Result of the method</returns>
        public List<CollaboratorModel> GetCollaborator(int noteId)
        {
            return this.repository.GetCollaborator(noteId);
        }

        /// <summary>
        /// Remove Collaborator Method
        /// </summary>
        /// <param name="collaboratorId">The Parameter</param>
        /// <returns>Result of the Method</returns>
        public bool RemoveCollaborator(int collaboratorId)
        {
            return this.repository.RemoveCollaborator(collaboratorId);
        }
    }
}
