using HotelReservation.Entities;
using HotelReservation.Models;

namespace HotelReservation.Interfaces
{
	public interface ICostumerService
	{
		IEnumerable<Customer> GetCustomers();
		CustomerModel GetCustomer(int id);
		CustomerModel CreateCustomer(CustomerModel customer);
		void Delete(int id);

		void UpdateCustomer(CustomerModel customer);
	}
}
