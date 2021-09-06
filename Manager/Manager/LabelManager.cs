// ----------------------------------------------------------------------------------------------------------
// <copyright file="LabelManager.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Manager.Manager
{
    using global::Manager.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// Label Manager class
    /// </summary>
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// Object for ILabelRepository
        /// </summary>
        private readonly ILabelRepository repository;

        /// <summary>
        /// Initializes a new instance of the LabelManager class
        /// </summary>
        /// <param name="repository">The Parameter</param>
        public LabelManager(ILabelRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Create Label Method
        /// </summary>
        /// <param name="labelModel">The Parameter</param>
        /// <returns>Result of the boolean</returns>
        public bool CreateLabel(LabelModel labelModel)
        {
            return this.repository.CreateLabel(labelModel);
        }
    }
}
