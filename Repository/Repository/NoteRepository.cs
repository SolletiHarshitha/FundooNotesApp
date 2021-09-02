// ----------------------------------------------------------------------------------------------------------
// <copyright file="NoteRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// Note Repository class
    /// </summary>
    public class NoteRepository : INoteRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the NoteRepository class
        /// </summary>
        /// <param name="userContext">UserContext userContext</param>
        public NoteRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Method to add a note
        /// </summary>
        /// <param name="noteData">Data needed to add a note</param>
        /// <returns>Returns the status of the add note</returns>
        public string AddNote(NotesModel noteData)
        {
            try
            {
                this.userContext.Notes.Add(noteData);
                this.userContext.SaveChanges();
                return "Added Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}