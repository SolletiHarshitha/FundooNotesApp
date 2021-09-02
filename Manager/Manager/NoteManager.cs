// ----------------------------------------------------------------------------------------------------------
// <copyright file="NoteManager.cs" company="Bridgelabz"> 
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
    /// NoteManager Class
    /// </summary>
    public class NoteManager : INoteManager
    {
        /// <summary>
        /// Object for INoteRepository
        /// </summary>
        private readonly INoteRepository repository;

        /// <summary>
        /// Initializes a new instance of the NoteManager class
        /// </summary>
        /// <param name="repository">INoteRepository repository</param>
        public NoteManager(INoteRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// AddNote Method
        /// </summary>
        /// <param name="noteData">Data to add note</param>
        /// <returns>Result of the action</returns>
        public string AddNote(NotesModel noteData)
        {
            return this.repository.AddNote(noteData);
        }
    }
}