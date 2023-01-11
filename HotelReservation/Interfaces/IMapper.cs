using HotelReservation.Entities;
using HotelReservation.Models;

namespace HotelReservation.Interfaces
{
	public interface IMapper <TEntity, TModel> 
	{
		Customer MapFromModelToEntity(CustomerModel model);
		CustomerModel MapFromEntityToModel(Customer entity);
	}
}
