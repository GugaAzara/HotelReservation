using HotelReservation.Entities;
using HotelReservation.Models;

namespace HotelReservation.Interfaces
{
	public interface IRoomService
	{
		IEnumerable<Room> GetRooms();
		IEnumerable<Room> GetRoomsByNumber(string name);

        RoomModel CreateRoom(RoomModel room);
		RoomModel GetRoom(int id);
		void DeleteRoom(int id);
		void UpdateRoom(RoomModel room);
    }
}
