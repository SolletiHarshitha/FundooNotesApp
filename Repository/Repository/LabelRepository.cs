// ----------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using System.Linq;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;
    
    /// <summary>
    /// Label Repository class
    /// </summary>
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// Object for User context
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the LabelRepository class
        /// </summary>
        /// <param name="userContext">The Parameter</param>
        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Create Label Method
        /// </summary>
        /// <param name="labelModel">The Parameter</param>
        /// <returns>Return boolean value</returns>
        public bool CreateLabel(LabelModel labelModel)
        {
            try
            {
                var label = this.userContext.Label.Where(x => x.UserId == labelModel.UserId && x.LabelName == labelModel.LabelName).SingleOrDefault();
                if (label == null)
                {
                    this.userContext.Label.Add(labelModel);
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
