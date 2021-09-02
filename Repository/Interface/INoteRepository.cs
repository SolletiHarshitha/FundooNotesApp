// ----------------------------------------------------------------------------------------------------------
// <copyright file="INoteRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Interface
{
    using Models;

    /// <summary>
    /// INoteRepository repository
    /// </summary>
    public interface INoteRepository
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

        /// <summary>
        /// Delete Note Interface
        /// </summary>
        /// <param name="id">To Delete Note</param>
        /// <returns>Result of the action</returns>
        string DeleteNoteForever(int id);
    }
}