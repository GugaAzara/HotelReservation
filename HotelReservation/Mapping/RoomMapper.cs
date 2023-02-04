using HotelReservation.Entities;
using HotelReservation.Interfaces;
using HotelReservation.Models;

namespace HotelReservation.Mapping
{
	public class RoomMapper : IRoomMapper<Room, RoomModel>
	{
		public Room MapFromModelToEntity(RoomModel model)
		{
			Room entity = new Room();
			entity.Id = model.Id;
			entity.RoomNumber = model.RoomNumber;
			entity.Category = model.Category;
			entity.Bed = model.Bed;
			entity.Status = model.Status;

			return entity;
		}

		public RoomModel MapFromEntityToModel(Room entity)
		{
			RoomModel model = new RoomModel();
			model.Id = entity.Id;
			model.RoomNumber = entity.RoomNumber;
			model.Category = entity.Category;
			model.Bed = entity.Bed;
			model.Status = entity.Status;

			return model;
		}

	}
}
