// ----------------------------------------------------------------------------------------------------------
// <copyright file="NoteManager.cs" company="Bridgelabz"> 
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

        /// <summary>
        /// Update Note Method
        /// </summary>
        /// <param name="noteData">To Update note</param>
        /// <returns>Result of the action</returns>
        public string UpdateNote(NotesModel noteData)
        {
            return this.repository.UpdateNote(noteData);
        }

        /// <summary>
        /// Delete Note Method
        /// </summary>
        /// <param name="id">To Delete Note</param>
        /// <returns>Result of the action</returns>
        public string DeleteNoteMoveToTrash(int id)
        {
            return this.repository.DeleteNoteMoveToTrash(id);
        }

        /// <summary>
        /// Delete Note Method
        /// </summary>
        /// <param name="id">Delete Note Forever</param>
        /// <returns>Result of the action</returns>
        public string DeleteNoteForever(int id)
        {
            return this.repository.DeleteNoteForever(id);
        }

        /// <summary>
        /// Archive Note Method
        /// </summary>
        /// <param name="noteId">Data to archive</param>
        /// <returns>Result of the action</returns>
        public string ArchiveNote(int noteId)
        {
            return this.repository.ArchiveNote(noteId);
        }

        /// <summary>
        /// UnArchive Note Method
        /// </summary>
        /// <param name="noteId">Data to UnArchive</param>
        /// <returns>Result of the action</returns>
        public string UnArchiveNote(int noteId)
        {
            return this.repository.UnArchiveNote(noteId);
        }

        /// <summary>
        /// Pin Note Method
        /// </summary>
        /// <param name="noteId">Pin Data</param>
        /// <returns>Result of the action</returns>
        public string PinNote(int noteId)
        {
            return this.repository.PinNote(noteId);
        }

        /// <summary>
        /// UnPin Note Method
        /// </summary>
        /// <param name="noteId">UnPin Data</param>
        /// <returns>Result of the action</returns>
        public string UnPinNote(int noteId)
        {
            return this.repository.UnPinNote(noteId);
        }

        /// <summary>
        /// Get color Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <param name="color">Color Parameter</param>
        /// <returns>Result of the action</returns>
        public string GetColor(int noteId, string color)
        {
            return this.repository.GetColor(noteId, color);
        }

        /// <summary>
        /// Restore Note Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <returns>Result of the action</returns>
        public string RestoreNote(int noteId)
        {
            return this.repository.RestoreNote(noteId);
        }

        /// <summary>
        /// Add Reminder Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <param name="reminder">Reminder Parameter</param>
        /// <returns>Result of the method</returns>
        public string RemindMe(int noteId, string reminder)
        {
            return this.repository.RemindMe(noteId, reminder);
        }

        /// <summary>
        /// Delete Reminder Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <returns>Result of the method</returns>
        public string DeleteReminder(int noteId)
        {
            return this.repository.DeleteReminder(noteId);
        }

        /// <summary>
        /// Empty Trash Method
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>Result of the method</returns>
        public bool EmptyTrash(int userId)
        {
            return this.repository.EmptyTrash(userId);
        }

        /// <summary>
        /// Get Trash Notes Method
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>Result of the method</returns>
        public List<NotesModel> GetTrashNotes(int userId)
        {
            return this.repository.GetTrashNotes(userId);
        }

        /// <summary>
        /// Get Archive Notes Method
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>Result of the method</returns>
        public List<NotesModel> GetArchiveNotes(int userId)
        {
            return this.repository.GetArchiveNotes(userId);
        }
    }
}