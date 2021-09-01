// ----------------------------------------------------------------------------------------------------------
// <copyright file="ResetPasswordModel.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Reset Password Class contains the fields to reset the password
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets the email 
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the new password 
        /// </summary>
        [Required]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the confirm password
        /// </summary>
        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
