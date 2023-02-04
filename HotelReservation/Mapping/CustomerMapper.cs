using HotelReservation.Entities;
using HotelReservation.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using HotelReservation.Models;

namespace HotelReservation.Mapping
{
	public class CustomerMapper : ICustomerMapper<Customer, CustomerModel>
	{
		public Customer MapFromModelToEntity(CustomerModel model)
		{
			Customer customer = new Customer();
			customer.Id = model.Id;
			customer.FullName= model.FullName;
			customer.Email= model.Email;
			customer.Phone= model.Phone;
			customer.Etnicity= model.Etnicity;
			customer.DateOfBirth = model.DateOfBirth;

			return customer;
		}

		public CustomerModel MapFromEntityToModel(Customer entity)
		{
			CustomerModel model = new CustomerModel();
			model.Id = entity.Id;
			model.FullName = entity.FullName;
			model.Email = entity.Email;
			model.Phone = entity.Phone;
			model.Etnicity= entity.Etnicity;
			model.DateOfBirth= entity.DateOfBirth;

			return model;
		}
	}
}
