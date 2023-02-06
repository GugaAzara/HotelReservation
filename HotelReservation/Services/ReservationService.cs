using HotelReservation.Data;
using HotelReservation.Entities;
using HotelReservation.Interfaces;
using HotelReservation.Mapping;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Pkcs;

namespace HotelReservation.Services
{
	public class ReservationService : IReservationService
	{
		public readonly HotelReservationContext _context;
        public readonly IReservationMapper<Reservation,ReservationModel> _reservationMapper;

		public ReservationService(HotelReservationContext context)
		{
            _reservationMapper = new ReservationMapper();
			_context = context;
		}

		public IEnumerable<Reservation> GetReservations()
		{
			var allReservations = _context.Reservations;
			return allReservations;
		}
        public ReservationModel GetReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);

            if (reservation == null)
            {
				throw new DbUpdateException($"Reservation with id {id} doesn't exists.");
			}

            var convertedEntity = _reservationMapper.MapFromEntityToModel(reservation);

            return convertedEntity;
        }


        public ReservationModel CreateReservation(ReservationModel reservation)
        {
            var checkreservation = _context.Reservations.Any(p => p.Room.Id == Int16.Parse(reservation.SelectedRoomId) && p.From == reservation.From && p.To == reservation.To);
            if (checkreservation)
            {
                throw new DbUpdateException($"Reservation From {reservation.From} to {reservation.To} with room {Int16.Parse(reservation.SelectedRoomId)}, already exists.");
            }

            var CustomerId = int.Parse(reservation.SelectedCustomerId);
            var RoomId = int.Parse(reservation.SelectedRoomId);

            var customer = _context.Customers.Find(CustomerId);
            var room = _context.Rooms.Find(RoomId);

            reservation.CustomerId = CustomerId;
            reservation.RoomId = RoomId;
            reservation.Room = room;
            reservation.Customer = customer;
            

            var convertedModel = _reservationMapper.MapFromModelToEntity(reservation);

            _context.Reservations.Add(convertedModel);
            _context.SaveChanges();

            return reservation;
        }

        public void UpdateReservation(ReservationModel reservation)
        {
			var checkreservation = _context.Reservations.Any(p => p.Room.Id == Int16.Parse(reservation.SelectedRoomId) && p.From == reservation.From && p.To == reservation.To);
			if (checkreservation)
			{
				throw new DbUpdateException($"Reservation From {reservation.From} to {reservation.To} with room {Int16.Parse(reservation.SelectedRoomId)}, already exists.");
			}

            var reservationToUpdate = _context.Reservations.Find(reservation.Id);

            // ------------- Get Customer and room by Select Value --------
			var CustomerId = int.Parse(reservation.SelectedCustomerId);
			var RoomId = int.Parse(reservation.SelectedRoomId);

			var customer = _context.Customers.Find(CustomerId);
			var room = _context.Rooms.Find(RoomId);
                                                                 
			reservation.CustomerId = CustomerId;
			reservation.RoomId = RoomId;
			reservation.Customer = customer;
			reservation.Room = room;
            // ------------------------------------------------------------

            reservationToUpdate.CustomerId = (int)reservation.CustomerId;
            reservationToUpdate.Customer = reservation.Customer;
            reservationToUpdate.From = reservation.From;
            reservationToUpdate.To = reservation.To;
            reservationToUpdate.RoomId = (int)reservation.RoomId;
            reservationToUpdate.Room = reservation.Room;
            reservationToUpdate.Price = reservation.Price;

            _context.SaveChanges();

		}




    }

}
