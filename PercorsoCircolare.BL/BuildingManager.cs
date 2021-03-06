﻿using System;
using System.Collections.Generic;
using PercorsoCircolare.Common;
using PercorsoCircolare.DAL;
using PercorsoCircolare.Entities;

namespace PercorsoCircolare.BL
{
    public class BuildingManager
    {
        private readonly BuildingRepo repo = new BuildingRepo();

        /// <summary>
        /// Returns a List with all the buildings
        /// </summary>
        /// <returns>A list of all Building(Entities)</returns>
        public IEnumerable<Building> GetAllBuildings()
        {
            try
            {
                LogManager.Info("get all buildings");
                return repo.GetAll();
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Returns a Building with a specific id
        /// </summary>
        /// <param name="id">The building id</param>
        /// <returns>The building identified</returns>
        public Building GetBuildingById(int id)
        {
            try
            {
                return repo.Single(r => r.BuildingId == id);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Create a given building on registry
        /// </summary>
        /// <param name="newBuilding">New building to create</param>
        public void AddNewBuilding(Building newBuilding)
        {
            try
            {
                repo.Add(newBuilding);
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
