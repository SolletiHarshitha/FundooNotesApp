// ----------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// Collaborator Repository
    /// </summary>
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// Object for User context
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
        /// AddCollaborator method
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Boolean Value</returns>
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
        
        /// <summary>
        /// GetCollaborator Method
        /// </summary>
        /// <param name="noteId">The parameter</param>
        /// <returns>List of values</returns>
        public List<CollaboratorModel> GetCollaborator(int noteId)
        {
            try 
            {
                var note = this.userContext.Collaborator.Where(x => x.NoteId == noteId).ToList();
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
