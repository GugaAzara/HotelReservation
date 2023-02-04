using HotelReservation.Entities;
using HotelReservation.Enums;

namespace HotelReservation.Models
{
	public class RoomModel
	{
		public int Id { get; set; }
		public string RoomNumber { get; set; }
		public RoomCategory Category { get; set; }
		public BedFormation Bed { get; set; }
		public Status Status { get; set; }

	}
}
