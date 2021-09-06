// ----------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using Models;

    /// <summary>
    /// ICollaboratorManager Interface
    /// </summary>
    public interface ICollaboratorManager
    {
        /// <summary>
        /// Add Collaborator
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Boolean value</returns>
        bool AddCollaborator(CollaboratorModel collaborator);
    }
}
