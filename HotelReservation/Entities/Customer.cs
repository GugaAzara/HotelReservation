namespace HotelReservation.Entities
{
	public class Customer 
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? Etnicity { get; set; }
		public DateTime DateOfBirth { get; set; }
	

		public List<Reservation> Reservations { get; set; }
	}
}
