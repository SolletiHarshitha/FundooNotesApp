// ----------------------------------------------------------------------------------------------------------
// <copyright file="ILabelManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// ILabel Manager Interface
    /// </summary>
    public interface ILabelManager
    {
        /// <summary>
        /// Create Label Method
        /// </summary>
        /// <param name="labelModel">The Parameter</param>
        /// <returns>Boolean Value</returns>
        bool CreateLabel(LabelModel labelModel);

        /// <summary>
        /// Remove Label Method
        /// </summary>
        /// <param name="labelId">The Parameter</param>
        /// <returns>Boolean Value</returns>
        bool RemoveLabel(int labelId);

        /// <summary>
        /// Delete Label
        /// </summary>
        /// <param name="userId">User Id Parameter</param>
        /// <param name="labelName">Label Name Parameter</param>
        /// <returns>Boolean Value</returns>
        bool DeleteLabel(int userId, string labelName);

        /// <summary>
        /// Get Label By User Id
        /// </summary>
        /// <param name="userId">The Parameter</param>
        /// <returns>List of labels</returns>
        public List<LabelModel> GetLabelByUserId(int userId);

        /// <summary>
        /// Add label
        /// </summary>
        /// <param name="labelModel">The Parameter</param>
        /// <returns>Boolean Value</returns>
        bool AddLabel(LabelModel labelModel);

        /// <summary>
        /// Get Label By Note Id
        /// </summary>
        /// <param name="noteId">The Parameter</param>
        /// <returns>List of labels</returns>
        public List<LabelModel> GetLabelByNoteId(int noteId);

        /// <summary>
        /// Edit Label
        /// </summary>
        /// <param name="updateLabel">The Parameter</param>
        /// <returns>Boolean Value</returns>
        bool EditLabel(UpdateLabelModel updateLabel);
    }
}
