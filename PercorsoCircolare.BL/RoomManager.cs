using System;
using System.Collections.Generic;
using PercorsoCircolare.Common;
using PercorsoCircolare.DAL;
using PercorsoCircolare.Entities;

namespace PercorsoCircolare.BL
{
    public class RoomManager
    {
        private readonly RoomRepo repo = new RoomRepo();

        /// <summary>
        /// Returns a list of all rooms
        /// </summary>
        /// <returns>A list of all rooms</returns>
        public IEnumerable<Room> GetAllRooms()
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
        /// Return a Room with a specific id
        /// </summary>
        /// <param name="id">The room id</param>
        /// <returns>The room identified</returns>
        public Room GetRoomById(int id)
        {
            try
            {
                return repo.Single(r => r.RoomId == id);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Create the given room on Registry
        /// </summary>
        /// <param name="newRoom">The new room to create</param>
        public void AddNewRoom(Room newRoom)
        {
            try
            {
                repo.Add(newRoom);
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
