// ----------------------------------------------------------------------------------------------------------
// <copyright file="INoteManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using Models;

    /// <summary>
    /// INoteManager Interface
    /// </summary>
    public interface INoteManager
    {
        /// <summary>
        /// AddNote Method
        /// </summary>
        /// <param name="noteData">Note details to add</param>
        /// <returns>Result of the action</returns>
        string AddNote(NotesModel noteData);

        /// <summary>
        /// Update Note Interface
        /// </summary>
        /// <param name="noteData">To Update Note</param>
        /// <returns>Result of the action</returns>
        string UpdateNote(NotesModel noteData);

        /// <summary>
        /// Delete Note Interface
        /// </summary>
        /// <param name="id">To Delete Note</param>
        /// <returns>Result of the action</returns>
        string DeleteNoteMoveToTrash(int id);
    }
}
