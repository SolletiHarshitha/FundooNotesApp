// ----------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="Bridgelabz"> 
// Copyright © 2021 Company="BridgeLabz" 
// </copyright> 
// <creator name="Harshitha Solleti"/> 
// ----------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
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
                    label.NoteId = null;
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

        /// <summary>
        /// Remove Label Method
        /// </summary>
        /// <param name="labelId">The Parameter</param>
        /// <returns>Return Boolean Value</returns>
        public bool RemoveLabel(int labelId)
        {
            try
            {
                var label = this.userContext.Label.Find(labelId);
                if (label != null)
                {
                    this.userContext.Label.Remove(label);
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
        
        /// <summary>
        /// Delete Label
        /// </summary>
        /// <param name="userId">User Id Parameter</param>
        /// <param name="labelName">Label name parameter</param>
        /// <returns>Return boolean Value</returns>
        public bool DeleteLabel(int userId, string labelName)
        {
            try
            {
                var label = this.userContext.Label.Where(x => x.UserId == userId && x.LabelName == labelName).ToList();
                if (label != null)
                {
                    this.userContext.Label.RemoveRange(label);
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

        /// <summary>
        /// Get Label by User id
        /// </summary>
        /// <param name="userId">The Parameter</param>
        /// <returns>List of labels</returns>
        public List<LabelModel> GetLabelByUserId(int userId)
        {
            try
            {
                var label = this.userContext.Label.Where(x => x.UserId == userId).ToList();
                return label;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add Label Method
        /// </summary>
        /// <param name="labelModel">The Parameter</param>
        /// <returns>Result of the method</returns>
        public bool AddLabel(LabelModel labelModel)
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

        /// <summary>
        /// Get Label By Note Id
        /// </summary>
        /// <param name="noteId">The Parameter</param>
        /// <returns>List of labels</returns>
        public List<LabelModel> GetLabelByNoteId(int noteId)
        {
            try
            {
                var label = this.userContext.Label.Where(x => x.NoteId == noteId).ToList();
                return label;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edit Label
        /// </summary>
        /// <param name="updateLabel">The Parameter</param>
        /// <returns>Result of the method</returns>
        public bool EditLabel(UpdateLabelModel updateLabel)
        {
            try 
            {
                var label = this.userContext.Label.Where(x => x.UserId == updateLabel.UserId && x.LabelName == updateLabel.LabelName).ToList();
                if (label != null)
                {
                    foreach (var l in label)
                    {
                        l.LabelName = updateLabel.NewLabelName;
                        this.userContext.Label.Update(l);
                        this.userContext.SaveChanges();
                    }

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
