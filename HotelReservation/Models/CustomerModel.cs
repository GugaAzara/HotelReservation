namespace HotelReservation.Models
{
	public class CustomerModel
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? Etnicity { get; set; }
		public DateTime DateOfBirth { get; set; }	
	}
}
