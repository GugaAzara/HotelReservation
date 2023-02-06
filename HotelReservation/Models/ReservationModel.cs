using HotelReservation.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace HotelReservation.Models
{
	public class ReservationModel
	{
		public int Id { get; set; }
		public int? CustomerId { get; set; }
		public Customer? Customer { get; set; }
		public int? RoomId { get; set; }
		public Room? Room { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public int Price { get; set; }

		/*Dropdown For Customers*/
		[DisplayName("Customer")]
		public string SelectedCustomerId { get; set; }
		public List<SelectListItem>? CustomerSelectList { get; set; }

		/*Dropdown For Rooms*/
		[DisplayName("Room")]
		public string SelectedRoomId { get; set; }
		public List<SelectListItem>? RoomSelectList { get; set; }

	}
}
