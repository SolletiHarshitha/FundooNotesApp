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
        /// AddCollaborator Method
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Result of the boolean method</returns>
        bool AddCollaborator(CollaboratorModel collaborator);
    }
}
