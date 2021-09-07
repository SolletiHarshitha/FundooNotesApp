// ----------------------------------------------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using Manager.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <summary>
    /// Label Controller class
    /// </summary>
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// Object for ILabelManager
        /// </summary>
        private readonly ILabelManager manager;

        /// <summary>
        /// Initializes a new instance of the LabelController class
        /// </summary>
        /// <param name="manager">The Parameter</param>
        public LabelController(ILabelManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Create Label API
        /// </summary>
        /// <param name="labelModel">The Parameter</param>
        /// <returns>Result of the action</returns>
        [HttpPost]
        [Route("api/CreateLabel")]
        public IActionResult CreateLabel([FromBody]LabelModel labelModel)
        {
            try
            {
                bool result = this.manager.CreateLabel(labelModel);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Label added Successfully!" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed to add Label" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Remove Label API
        /// </summary>
        /// <param name="labelId">The Parameter</param>
        /// <returns>Result of the action</returns>
        [HttpDelete]
        [Route("api/RemoveLabel")]
        public IActionResult RemoveLabel(int labelId)
        {
            try
            {
                bool result = this.manager.RemoveLabel(labelId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Label removed" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed to remove label" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete Label API
        /// </summary>
        /// <param name="userId">User Id Parameter</param>
        /// <param name="labelName">Label Name Parameter</param>
        /// <returns>Result of the action</returns>
        [HttpDelete]
        [Route("api/DeleteLabel")]
        public IActionResult DeleteLabel(int userId, string labelName)
        {
            try
            {
                bool result = this.manager.DeleteLabel(userId, labelName);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Label Deleted Successfully!" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed to delete label" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get Label API
        /// </summary>
        /// <param name="userId">The Parameter</param>
        /// <returns>Result of the action</returns>
        [HttpGet]
        [Route("api/GetLabelByUserId")]
        public IActionResult GetLabelByUserId(int userId)
        {
            try
            {
                List<LabelModel> result = this.manager.GetLabelByUserId(userId);
                if (result.Count > 0)
                {
                    return this.Ok(new { Status = true, Message = "List of Labels", Data = result }); 
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed to retrieve list" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Add Label API
        /// </summary>
        /// <param name="labelModel">The Parameter</param>
        /// <returns>Result of the action</returns>
        [HttpPost]
        [Route("api/AddLabel")]
        public IActionResult AddLabel([FromBody] LabelModel labelModel)
        {
            try
            {
                bool result = this.manager.AddLabel(labelModel);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Label added Successfully!" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed to add Label" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get Label By Note Id
        /// </summary>
        /// <param name="noteId">The Parameter</param>
        /// <returns>Result of the action</returns>
        [HttpGet]
        [Route("api/GetLabelByNoteId")]
        public IActionResult GetLabelByNoteId(int noteId)
        {
            try
            {
                List<LabelModel> result = this.manager.GetLabelByNoteId(noteId);
                if (result.Count > 0)
                {
                    return this.Ok(new { Status = true, Message = "List of Labels", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed to retrieve list" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
