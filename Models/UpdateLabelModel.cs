// ----------------------------------------------------------------------------------------------------------
// <copyright file="UpdateLabelModel.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Update Label Model Class
    /// </summary>
    public class UpdateLabelModel
    {
        /// <summary>
        /// Gets or sets User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Label Name
        /// </summary>
        public string LabelName { get; set; }

        /// <summary>
        /// Gets or sets Updated Label Name
        /// </summary>
        public string NewLabelName { get; set; }
    }
}
