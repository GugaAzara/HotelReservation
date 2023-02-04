using HotelReservation.Entities;
using HotelReservation.Models;

namespace HotelReservation.Interfaces
{
    public interface IReservationMapper <TEntity, TModel>
    {
        Reservation MapFromModelToEntity(ReservationModel model);
        ReservationModel MapFromEntityToModel(Reservation entity);
    }
}
