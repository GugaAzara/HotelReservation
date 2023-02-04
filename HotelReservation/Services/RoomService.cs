using HotelReservation.Data;
using HotelReservation.Entities;
using HotelReservation.Interfaces;
using HotelReservation.Mapping;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Services
{
	public class RoomService : IRoomService
	{
		public readonly HotelReservationContext _context;
		public readonly IRoomMapper<Room, RoomModel> _roomMapper;

		public RoomService(HotelReservationContext contex)
		{
			_roomMapper = new RoomMapper();
			_context = contex;
		}

		public IEnumerable<Room> GetRoomsByNumber(string name)
		{
			
			return _context.Rooms.Where(c => c.RoomNumber.Contains(name));
			
		}

        public IEnumerable<Room> GetRooms()
		{
            return _context.Rooms;
        }


        public RoomModel GetRoom(int id)
		{
			var room = _context.Rooms.Find(id);
			if (room == null)
			{
				throw new DbUpdateException("Room doesn't exist");
			}

			var convertedEntity = _roomMapper.MapFromEntityToModel(room);
			return convertedEntity;
		}

		public RoomModel CreateRoom(RoomModel room)
		{
			var checkRoomNumber = _context.Rooms.Any(p => p.RoomNumber == room.RoomNumber);
			if (checkRoomNumber)
			{
				throw new DbUpdateException($"Room with room number {room.RoomNumber}, already exists.");
			}

			var convertedModel = _roomMapper.MapFromModelToEntity(room);

			_context.Rooms.Add(convertedModel);
			_context.SaveChanges();

			return room;
		}

		public void DeleteRoom(int id)
		{
			var roomToDelete = _context.Rooms.Find(id);
			if(roomToDelete == null)
			{
				throw new DbUpdateException($"Room with id {id} doesn't exist.");
			}

			_context.Rooms.Remove(roomToDelete);
			_context.SaveChanges();
		}

		public void UpdateRoom(RoomModel room)
		{
			var roomToUpdate = _context.Rooms.Find(room.Id);
			if(roomToUpdate == null )
			{
                throw new DbUpdateException($"Room with id {room.Id} doesn't exist.");
            }

			roomToUpdate.RoomNumber = room.RoomNumber;
			roomToUpdate.Category = room.Category;
			roomToUpdate.Bed = room.Bed;
			roomToUpdate.Status = room.Status;

			_context.SaveChanges();
		}
	}
}
