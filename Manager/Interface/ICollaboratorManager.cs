// ----------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// ICollaboratorManager Interface
    /// </summary>
    public interface ICollaboratorManager
    {
        /// <summary>
        /// AddCollaborator Method
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Result of the boolean method</returns>
        bool AddCollaborator(CollaboratorModel collaborator);

        /// <summary>
        /// Get Collaborator Method
        /// </summary>
        /// <param name="noteId">The Parameter</param>
        /// <returns>Result of Boolean Method</returns>
        public List<CollaboratorModel> GetCollaborator(int noteId);

        /// <summary>
        /// Remove Collaborator
        /// </summary>
        /// <param name="collaboratorId">The Parameter</param>
        /// <returns>Result of Boolean Method</returns>
        bool RemoveCollaborator(int collaboratorId);
    }
}
