// ----------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using global::Repository.Context;
    using global::Repository.Interface;
    using Models;
    using System;

    /// <summary>
    /// Collaborator Repository Class
    /// </summary>
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the CollaboratorRepository class
        /// </summary>
        /// <param name="userContext">The Parameter</param>
        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Add Collaborator class
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Result of the boolean method</returns>
        public bool AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                if (collaborator != null)
                {
                    this.userContext.Collaborator.Add(collaborator);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
