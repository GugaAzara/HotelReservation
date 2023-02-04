using HotelReservation.Entities;
using HotelReservation.Models;

namespace HotelReservation.Interfaces
{
	public interface IRoomMapper<TEntity, TModel>
	{
		Room MapFromModelToEntity(RoomModel model);
		RoomModel MapFromEntityToModel(Room entity);
	}
}
