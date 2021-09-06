// ----------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Interface
{
    using Models;

    /// <summary>
    /// ICollaborator Repository Interface
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// Add Collaborator
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Boolean value</returns>
        bool AddCollaborator(CollaboratorModel collaborator);
    }
}
