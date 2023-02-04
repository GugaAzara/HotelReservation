using HotelReservation.Entities;
using HotelReservation.Interfaces;
using HotelReservation.Models;

namespace HotelReservation.Mapping
{
    public class ReservationMapper : IReservationMapper<Reservation, ReservationModel>
    {
        public Reservation MapFromModelToEntity(ReservationModel model)
        {
            Reservation reservation = new Reservation();
            reservation.Id = model.Id;
            reservation.CustomerId = (int)model.CustomerId;
            reservation.Customer = model.Customer;
            reservation.RoomId = (int)model.RoomId;
            reservation.Room = model.Room;
            reservation.From = model.From;
            reservation.To = model.To;
            reservation.Price = model.Price;
            
            

            return reservation;
        }

        public ReservationModel MapFromEntityToModel(Reservation entity)
        {
            ReservationModel model = new ReservationModel();
            model.Id = entity.Id;
            model.CustomerId = entity.CustomerId;
            model.Customer = entity.Customer;
            model.RoomId = entity.RoomId;
            model.Room = entity.Room;
			model.From = entity.From;
            model.To = entity.To;
            model.Price = entity.Price;

            return model;
        }
    }
}
