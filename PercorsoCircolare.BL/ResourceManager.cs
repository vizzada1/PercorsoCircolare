using System;
using System.Collections.Generic;
using PercorsoCircolare.Common;
using PercorsoCircolare.DAL;
using PercorsoCircolare.DAL.Entities;

namespace PercorsoCircolare.BL
{
    public class ResourceManager
    {
        private readonly ResourceRepo repo = new ResourceRepo();

        /// <summary>
        /// Returns a list of all Resources
        /// </summary>
        /// <returns>A list of all Resources(Entities)</returns>
        public IEnumerable<Resource> GetAllResources()
        {
            try
            {
                return repo.GetAll();
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Return a Resource with a specific identifier
        /// </summary>
        /// <param name="id">the Resource identifier</param>
        /// <returns>The resource identified</returns>
        public Resource GetResourceById(int id)
        {
            try
            {
                return repo.Single(s => s.ResourceId == id);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Return a Resource with a specific username
        /// </summary>
        /// <param name="username">The resource username</param>
        /// <returns>The resource identified</returns>
        public Resource GetResourceByUser(string username)
        {
            try
            {
                return repo.Single(r => r.Username == username);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Create the given user on Registry
        /// </summary>
        /// <param name="newResource">New Resource to create</param>
        public void AddNewResource(Resource newResource)
        {
            try
            {
                repo.Add(newResource);
                UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }
    }
}
