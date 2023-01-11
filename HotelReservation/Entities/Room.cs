using HotelReservation.Enums;

namespace HotelReservation.Entities
{
	public class Room
	{
		public int Id { get; set; }
		public string RoomNumber { get; set; }
		public RoomCategory Category { get; set; }
		public BedFormation Bed { get; set; }
		public Status Status { get; set; }

		public List<Reservation> Reservations { get; set; }
	}
}
