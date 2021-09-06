// ----------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="Bridgelabz"> 
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
    /// CollaboratorController class
    /// </summary>
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// Object for ICollaboratorManager
        /// </summary>
        private readonly ICollaboratorManager manager;

        /// <summary>
        /// Initializes a new instance of the CollaboratorController class
        /// </summary>
        /// <param name="manager">The Parameter</param>
        public CollaboratorController(ICollaboratorManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Add Collaborator API
        /// </summary>
        /// <param name="collaborator">The Parameter</param>
        /// <returns>Result of the action</returns>
        [HttpPost]
        [Route("api/AddCollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel collaborator)
        {
            try
            {
                bool result = this.manager.AddCollaborator(collaborator);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Collaborator added Successfully!" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Collaborator doesn't added" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get Collaborator API
        /// </summary>
        /// <param name="noteId">The Parameter</param>
        /// <returns>Result of the action</returns>
        [HttpGet]
        [Route("api/GetCollaborator")]
        public IActionResult GetCollaborator(int noteId)
        {
            try
            {
                List<CollaboratorModel> result = this.manager.GetCollaborator(noteId);
                if (result.Count > 0)
                {
                    return this.Ok(new { Status = true, Message = "Collaborator List", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed to Get Collaborator" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// RemoveCollaborator API
        /// </summary>
        /// <param name="collaboratorId">The Parameter</param>
        /// <returns>Result of the action</returns>
        [HttpDelete]
        [Route("api/RemoveCollaborator")]
        public IActionResult RemoveCollaborator(int collaboratorId)
        {
            try
            {
                bool result = this.manager.RemoveCollaborator(collaboratorId);
                if (result)
                {
                    return this.Ok(new { Status = true, Message = "Collaborator removed" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Collaborator doesn't removed" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
