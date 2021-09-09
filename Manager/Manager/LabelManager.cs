// ----------------------------------------------------------------------------------------------------------
// <copyright file="LabelManager.cs" company="Bridgelabz"> 
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
    /// Label Manager class
    /// </summary>
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// Object for ILabelRepository
        /// </summary>
        private readonly ILabelRepository repository;

        /// <summary>
        /// Initializes a new instance of the LabelManager class
        /// </summary>
        /// <param name="repository">The Parameter</param>
        public LabelManager(ILabelRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Create Label Method
        /// </summary>
        /// <param name="labelModel">The Parameter</param>
        /// <returns>Result of the boolean</returns>
        public bool CreateLabel(LabelModel labelModel)
        {
            return this.repository.CreateLabel(labelModel);
        }

        /// <summary>
        /// Remove Label Method
        /// </summary>
        /// <param name="labelId">The Parameter</param>
        /// <returns>Result of the boolean</returns>
        public bool RemoveLabel(int labelId)
        {
            return this.repository.RemoveLabel(labelId);
        }

        /// <summary>
        /// Delete Label Method
        /// </summary>
        /// <param name="userId">User Id Parameter</param>
        /// <param name="labelName">Label Name Parameter</param>
        /// <returns>Result of the boolean</returns>
        public bool DeleteLabel(int userId, string labelName)
        {
            return this.repository.DeleteLabel(userId, labelName);
        }

        /// <summary>
        /// Get Label By User Id
        /// </summary>
        /// <param name="userId">The Parameter</param>
        /// <returns>Result the list</returns>
        public List<LabelModel> GetLabelByUserId(int userId)
        {
            return this.repository.GetLabelByUserId(userId);
        }

        /// <summary>
        /// Get Label by Note Id
        /// </summary>
        /// <param name="noteId">The Parameter</param>
        /// <returns>Result List</returns>
        public List<LabelModel> GetLabelByNoteId(int noteId)
        {
            return this.repository.GetLabelByNoteId(noteId);
        }

        /// <summary>
        /// Edit Label
        /// </summary>
        /// <param name="updateLabel">The Parameter</param>
        /// <returns>Result of the boolean method</returns>
        public bool EditLabel(UpdateLabelModel updateLabel)
        {
            return this.repository.EditLabel(updateLabel);
        }
    }
}
