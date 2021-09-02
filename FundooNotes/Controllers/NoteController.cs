// ----------------------------------------------------------------------------------------------------------
// <copyright file="NoteController.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using Manager.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <summary>
    /// Note Controller Class
    /// </summary>
    public class NoteController : ControllerBase
    {
        /// <summary>
        /// Object for INoteManager
        /// </summary>
        private readonly INoteManager manager;

        /// <summary>
        /// Initializes a new instance of the NoteController class
        /// </summary>
        /// <param name="manager"> INoteManager manager</param>
        public NoteController(INoteManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Add Note API
        /// </summary>
        /// <param name="noteData">Data to add note</param>
        /// <returns>Result of the action</returns>
        [HttpPost]
        [Route("api/AddNote")]
        public IActionResult AddNote([FromBody] NotesModel noteData)
        {
            try
            {
                string resultMessage = this.manager.AddNote(noteData);
                if (resultMessage.Equals("Added Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "New Note Added Successful" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note doesn't added successfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Update Note API
        /// </summary>
        /// <param name="noteData">Data to update note</param>
        /// <returns>Result of the action</returns>
        [HttpPut]
        [Route("api/UpdateNote")]
        public IActionResult UpdateNote([FromBody] NotesModel noteData)
        {
            try
            {
                string resultMessage = this.manager.UpdateNote(noteData);
                if (resultMessage.Equals("Updated Successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Updated Successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note doesn't updated successfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete Note API
        /// </summary>
        /// <param name="noteId">Delete note</param>
        /// <returns>Result of the action</returns>
        [HttpDelete]
        [Route("api/DeleteNote")]
        public IActionResult DeleteNoteMoveToTrash(int noteId)
        {
            try
            {
                string resultMessage = this.manager.DeleteNoteMoveToTrash(noteId);
                if (resultMessage.Equals("Successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Moved to trash Successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note doesn't moved successfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete Note API
        /// </summary>
        /// <param name="noteId">Delete Note Forever</param>
        /// <returns>Result of the action</returns>
        [HttpDelete]
        [Route("api/DeleteNote")]
        public IActionResult DeleteNoteForever(int noteId)
        {
            try
            {
                string resultMessage = this.manager.DeleteNoteForever(noteId);
                if (resultMessage.Equals("Successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note deleted successfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}