using HotelReservation.Entities;
using HotelReservation.Models;

namespace HotelReservation.Interfaces
{
	public interface ICustomerMapper <TEntity, TModel> 
	{
		Customer MapFromModelToEntity(CustomerModel model);
		CustomerModel MapFromEntityToModel(Customer entity);

	}
}
