// ----------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Manager
{
    using global::Manager.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// Collaborator Manager class
    /// </summary>
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// Object for ICollaboratorRepository
        /// </summary>
        private readonly ICollaboratorRepository repository;

        /// <summary>
        /// Initializes a new instance of the CollaboratorManager class
        /// </summary>
        /// <param name="repository">ICollaboratorRepository repository</param>
        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Add Collaborator Method
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Boolean value</returns>
        public bool AddCollaborator(CollaboratorModel collaborator)
        {
            return this.repository.AddCollaborator(collaborator);
        }
    }
}
