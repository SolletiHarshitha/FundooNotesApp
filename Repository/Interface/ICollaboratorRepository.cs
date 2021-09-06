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
        /// AddCollaborator Method
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Result of Boolean Method</returns>
        bool AddCollaborator(CollaboratorModel collaborator);
    }
}
