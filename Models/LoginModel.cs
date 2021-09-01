// ----------------------------------------------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Login Model Class contains Login details
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the email 
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
