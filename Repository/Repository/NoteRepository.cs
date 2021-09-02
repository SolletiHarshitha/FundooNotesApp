// ----------------------------------------------------------------------------------------------------------
// <copyright file="NoteRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using System.Linq;
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

        /// <summary>
        /// Method to update a note
        /// </summary>
        /// <param name="noteData">Update note</param>
        /// <returns>Returns the update status</returns>
        public string UpdateNote(NotesModel noteData)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (note != null)
                {
                    note.Title = noteData.Title;
                    note.Description = noteData.Description;

                    this.userContext.Notes.Update(note);
                    this.userContext.SaveChanges();
                    return "Updated Successfully";
                }

                return "Not Updated";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Note API
        /// </summary>
        /// <param name="id">Delete Note</param>
        /// <returns>Returns the delete status</returns>
        public string DeleteNoteMoveToTrash(int id)
        {
            try 
            {
                var note = this.userContext.Notes.Find(id);
                if (note != null)
                {
                    note.Trash = true;
                    this.userContext.Notes.Update(note);
                    this.userContext.SaveChanges();
                    return "Successful";
                }

                return "Unsuccessful";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Note Forever API
        /// </summary>
        /// <param name="id">Delete Note</param>
        /// <returns>Returns the delete status</returns>
        public string DeleteNoteForever(int id)
        {
            try
            {
                var note = this.userContext.Notes.Find(id);
                if (note != null)
                {
                    this.userContext.Notes.Remove(note);
                    this.userContext.SaveChanges();
                    return "Successful";
                }

                return "Unsuccessful";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Archive Note Method
        /// </summary>
        /// <param name="noteId">Archive Note data</param>
        /// <returns>Returns the archive status</returns>
        public string ArchiveNote(int noteId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    note.Archive = true;

                    this.userContext.Notes.Update(note);
                    this.userContext.SaveChanges();
                    return "Successful";
                }

                return "Unsuccessful";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UnArchive Note Method
        /// </summary>
        /// <param name="noteId">UnArchive Note Data</param>
        /// <returns>Returns the archive status</returns>
        public string UnArchiveNote(int noteId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    note.Archive = false;

                    this.userContext.Notes.Update(note);
                    this.userContext.SaveChanges();
                    return "Successful";
                }

                return "Unsuccessful";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Pin Note Method
        /// </summary>
        /// <param name="noteId">Pin Note Data</param>
        /// <returns>Returns the pin status</returns>
        public string PinNote(int noteId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    note.Pin = true;

                    this.userContext.Notes.Update(note);
                    this.userContext.SaveChanges();
                    return "Successful";
                }

                return "Unsuccessful";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UnPin Note Method
        /// </summary>
        /// <param name="noteId">UnPin Note Data</param>
        /// <returns>Returns the pin status</returns>
        public string UnPinNote(int noteId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    note.Pin = false;

                    this.userContext.Notes.Update(note);
                    this.userContext.SaveChanges();
                    return "Successful";
                }

                return "Unsuccessful";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Color Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <param name="color">Color Parameter</param>
        /// <returns>Returns the status of color</returns>
        public string GetColor(int noteId, string color)
        {
            try 
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    note.Color = color;

                    this.userContext.Notes.Update(note);
                    this.userContext.SaveChanges();
                    return "Successful";
                }

                return "Unsuccessful";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restore Note Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <returns>returns the status of the restore note</returns>
        public string RestoreNote(int noteId)
        {
            try 
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (note != null)
                {
                    note.Trash = false;
                    this.userContext.Notes.Update(note);
                    this.userContext.SaveChanges();
                    return "Successful";
                }

                return "Unsuccessful";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}