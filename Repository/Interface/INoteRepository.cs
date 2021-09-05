// ----------------------------------------------------------------------------------------------------------
// <copyright file="INoteRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Interface
{
    using System.Collections.Generic;
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
        bool AddNote(NotesModel noteData);

        /// <summary>
        /// Update Note Interface
        /// </summary>
        /// <param name="noteData">To Update Note</param>
        /// <returns>Result of the action</returns>
        bool UpdateNote(NotesModel noteData);

        /// <summary>
        /// Delete Note Interface
        /// </summary>
        /// <param name="id">To Delete Note</param>
        /// <returns>Result of the action</returns>
        bool DeleteNoteMoveToTrash(int id);

        /// <summary>
        /// Delete Note Interface
        /// </summary>
        /// <param name="id">To Delete Note</param>
        /// <returns>Result of the action</returns>
        bool DeleteNoteForever(int id);

        /// <summary>
        /// Archive Note Interface
        /// </summary>
        /// <param name="noteId">To Archive Note</param>
        /// <returns>Result of the action</returns>
        bool ArchiveNote(int noteId);

        /// <summary>
        /// UnArchive Note Interface
        /// </summary>
        /// <param name="noteId">To UnArchive Note</param>
        /// <returns>Result of the action</returns>
        bool UnArchiveNote(int noteId);

        /// <summary>
        /// Pin Note Interface
        /// </summary>
        /// <param name="noteId">Pin Note</param>
        /// <returns>Result of the action</returns>
        bool PinNote(int noteId);

        /// <summary>
        /// UnPin Note Interface
        /// </summary>
        /// <param name="noteId">To UnPin Note</param>
        /// <returns>Result of the action</returns>
        bool UnPinNote(int noteId);

        /// <summary>
        /// Get Color Interface
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <param name="color">Color Parameter</param>
        /// <returns>Result of the action</returns>
        bool GetColor(int noteId, string color);

        /// <summary>
        /// Restore Note Interface
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <returns>Results of the action</returns>
        bool RestoreNote(int noteId);

        /// <summary>
        /// Add Reminder Interface
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <param name="reminder">Reminder Parameter</param>
        /// <returns>Result of the action</returns>
        bool RemindMe(int noteId, string reminder);

        /// <summary>
        /// Delete Reminder Interface
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <returns>Result of the action</returns>
        bool DeleteReminder(int noteId);

        /// <summary>
        /// Empty Trash Interface
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>Result of the action</returns>
        bool EmptyTrash(int userId);

        /// <summary>
        /// Get Trash Notes Interface
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>Result of the action</returns>
        public List<NotesModel> GetTrashNotes(int userId);

        /// <summary>
        /// Get Archive Interface
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>Result of the action</returns>
        public List<NotesModel> GetArchiveNotes(int userId);

        /// <summary>
        /// Get Reminder Interface
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>Result of the action</returns>
        public List<NotesModel> GetReminderNotes(int userId);

        /// <summary>
        /// Get Notes
        /// </summary>
        /// <param name="userId">User Id Parameter</param>
        /// <returns>Result of the action</returns>
        public List<NotesModel> GetNotes(int userId);
    }
}