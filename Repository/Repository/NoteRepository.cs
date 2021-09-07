// ----------------------------------------------------------------------------------------------------------
// <copyright file="NoteRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
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
        /// IConfiguration configuration
        /// </summary>
        private readonly IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the NoteRepository class
        /// </summary>
        /// <param name="userContext">UserContext userContext</param>
        /// <param name="configuration">IConfiguration configuration</param>
        public NoteRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.config = configuration;
        }

        /// <summary>
        /// Method to add a note
        /// </summary>
        /// <param name="noteData">Data needed to add a note</param>
        /// <returns>Returns the status of the add note</returns>
        public bool AddNote(NotesModel noteData)
        {
            try
            {
                this.userContext.Notes.Add(noteData);
                this.userContext.SaveChanges();
                return true;
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
        public bool UpdateNote(NotesModel noteData)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    note.Title = noteData.Title;
                    note.Description = noteData.Description;

                    this.userContext.Notes.Update(note);
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
        /// Delete Note API
        /// </summary>
        /// <param name="id">Delete Note</param>
        /// <returns>Returns the delete status</returns>
        public bool DeleteNoteMoveToTrash(int id)
        {
            try 
            {
                var note = this.userContext.Notes.Find(id);
                if (note != null)
                {
                    note.Trash = true;
                    note.Pin = false;

                    this.userContext.Notes.Update(note);
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
        /// Delete Note Forever API
        /// </summary>
        /// <param name="id">Delete Note</param>
        /// <returns>Returns the delete status</returns>
        public bool DeleteNoteForever(int id)
        {
            try
            {
                var note = this.userContext.Notes.Find(id);
                if (note != null)
                {
                    this.userContext.Notes.Remove(note);
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
        /// Archive Note Method
        /// </summary>
        /// <param name="noteId">Archive Note data</param>
        /// <returns>Returns the archive status</returns>
        public bool ArchiveNote(int noteId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    if (note.Pin == true)
                    {
                        note.Pin = false;
                    }

                    note.Archive = true;

                    this.userContext.Notes.Update(note);
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
        /// UnArchive Note Method
        /// </summary>
        /// <param name="noteId">UnArchive Note Data</param>
        /// <returns>Returns the archive status</returns>
        public bool UnArchiveNote(int noteId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    note.Archive = false;

                    this.userContext.Notes.Update(note);
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
        /// Pin Note Method
        /// </summary>
        /// <param name="noteId">Pin Note Data</param>
        /// <returns>Returns the pin status</returns>
        public bool PinNote(int noteId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    if (note.Archive == true)
                    {
                        note.Archive = false;
                    }

                    note.Pin = true;

                    this.userContext.Notes.Update(note);
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
        /// UnPin Note Method
        /// </summary>
        /// <param name="noteId">UnPin Note Data</param>
        /// <returns>Returns the pin status</returns>
        public bool UnPinNote(int noteId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    note.Pin = false;

                    this.userContext.Notes.Update(note);
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
        /// Get Color Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <param name="color">Color Parameter</param>
        /// <returns>Returns the status of color</returns>
        public bool GetColor(int noteId, string color)
        {
            try 
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Trash == false).FirstOrDefault();
                if (note != null)
                {
                    note.Color = color;

                    this.userContext.Notes.Update(note);
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
        /// Restore Note Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <returns>returns the status of the restore note</returns>
        public bool RestoreNote(int noteId)
        {
            try 
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (note != null)
                {
                    note.Trash = false;
                    this.userContext.Notes.Update(note);
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
        /// Add Reminder Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <param name="reminder">Reminder Parameter</param>
        /// <returns>Returns the Reminder status</returns>
        public bool RemindMe(int noteId, string reminder)
        {
            try 
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (note != null)
                {
                    note.Remainder = reminder;
                    this.userContext.Notes.Update(note);
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
        /// Delete Reminder Method
        /// </summary>
        /// <param name="noteId">Note Id Parameter</param>
        /// <returns>Returns the Delete Reminder status</returns>
        public bool DeleteReminder(int noteId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (note != null)
                {
                    note.Remainder = null;
                    this.userContext.Notes.Update(note);
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
        /// Empty Trash Method
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>Returns the Empty trash status</returns>
        public bool EmptyTrash(int userId)
        {
            try
            {
                var note = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == true).ToList();
                if (note.Count > 0)
                {
                    this.userContext.Notes.RemoveRange(note);
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
        /// Get Trash Notes Method
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>List of notes in trash</returns>
        public List<NotesModel> GetTrashNotes(int userId)
        {
            try
            {
                var trashNotes = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == true).ToList();
                return trashNotes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Archive Notes Method
        /// </summary>
        /// <param name="userId">User Id Parameter</param>
        /// <returns>List of notes in archive</returns>
        public List<NotesModel> GetArchiveNotes(int userId)
        {
            try
            {
                var trashNotes = this.userContext.Notes.Where(x => x.UserId == userId && x.Archive == true && x.Trash == false).ToList();
                return trashNotes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Reminder Notes
        /// </summary>
        /// <param name="userId">UserId Parameter</param>
        /// <returns>List of notes in reminders</returns>
        public List<NotesModel> GetReminderNotes(int userId)
        {
            try
            {
                var trashNotes = this.userContext.Notes.Where(x => x.UserId == userId && x.Remainder != null && x.Trash == false).ToList();
                return trashNotes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Notes
        /// </summary>
        /// <param name="userId">User Id Parameter</param>
        /// <returns>List of notes</returns>
        public List<NotesModel> GetNotes(int userId)
        {
            try 
            {
                var notes = this.userContext.Notes.Where(x => x.UserId == userId && x.Trash == false && x.Archive == false).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add Image
        /// </summary>
        /// <param name="noteId">note id Parameter</param>
        /// <param name="image">The Parameter</param>
        /// <returns>Result of the method</returns>
        public bool AddImage(int noteId, IFormFile image)
        {
            try 
            {
                Account account = new Account("dghxlt009", "651423643215437", "u756xpLyy5oYLhQ5861HHafriTs");
                Cloudinary cloudinary = new Cloudinary(account);
                var stream = image.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(Guid.NewGuid().ToString(), stream),
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                var path = uploadResult.Url;
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Image = path.ToString();
                    this.userContext.Notes.Update(note);
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
        /// Remove Image
        /// </summary>
        /// <param name="noteId">The Parameter</param>
        /// <returns>Result of the method</returns>
        public bool RemoveImage(int noteId)
        {
            try 
            {
                var note = this.userContext.Notes.Where(x => x.NoteId == noteId && x.Image != null).SingleOrDefault();
                if (note != null)
                {
                    note.Image = null;
                    this.userContext.Notes.Update(note);
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
    }
}