// ----------------------------------------------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz"> 
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
        [Route("api/AddLabel")]
        public IActionResult CreateLabel([FromBody]LabelModel labelModel)
        {
            try
            {
                bool result = this.manager.CreateLabel(labelModel);
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
    }
}
