using HotelReservation.Entities;
using HotelReservation.Models;

namespace HotelReservation.Interfaces
{
	public interface ICustomerService
	{
		IEnumerable<Customer> GetCustomers();
		IEnumerable<Customer> SearchCustomerByName(string name);
		CustomerModel GetCustomer(int id);

        CustomerModel CreateCustomer(CustomerModel customer);
		void Delete(int id);

		void UpdateCustomer(CustomerModel customer);
	}
}
