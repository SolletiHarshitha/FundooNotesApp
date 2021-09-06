// ----------------------------------------------------------------------------------------------------------
// <copyright file="ILabelManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using Models;

    /// <summary>
    /// ILabel Manager Interface
    /// </summary>
    public interface ILabelManager
    {
        /// <summary>
        /// Create Label Method
        /// </summary>
        /// <param name="labelModel">The Parameter</param>
        /// <returns>Boolean Value</returns>
        bool CreateLabel(LabelModel labelModel);
    }
}
