// ----------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// ICollaborator Repository Interface
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// AddCollaborator Method
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Result of Boolean Method</returns>
        bool AddCollaborator(CollaboratorModel collaborator);

        /// <summary>
        /// Get Collaborator Method
        /// </summary>
        /// <param name="noteId">The Parameter</param>
        /// <returns>Result of Boolean Method</returns>
        public List<CollaboratorModel> GetCollaborator(int noteId);

        /// <summary>
        /// Remove Collaborator Method
        /// </summary>
        /// <param name="collaboratorId">The Parameter</param>
        /// <returns>Result of Boolean Method</returns>
        bool RemoveCollaborator(int collaboratorId);
    }
}
