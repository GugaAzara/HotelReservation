using HotelReservation.Entities;
using HotelReservation.Models;

namespace HotelReservation.Interfaces
{
	public interface IReservationService
	{
		IEnumerable<Reservation> GetReservations();
		ReservationModel GetReservation(int id);
		ReservationModel CreateReservation(ReservationModel reservation);
		void UpdateReservation(ReservationModel reservation);


	}
}
