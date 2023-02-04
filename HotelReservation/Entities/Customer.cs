using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotelReservation.Entities
{
	public class Customer 
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? Etnicity { get; set; }

		[Display(Name = "Date of Birth")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }
	

		public List<Reservation> Reservations { get; set; }
	}
}
