using HotelReservation.Data;
using HotelReservation.Entities;
using HotelReservation.Interfaces;
using HotelReservation.Mapping;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace HotelReservation.Services
{
	public class CustomerService : ICustomerService
	{
		public readonly HotelReservationContext _context;
		public readonly ICustomerMapper<Customer, CustomerModel> _customermapper;

		public CustomerService(HotelReservationContext context)
		{
			_customermapper = new CustomerMapper();
			_context = context;
		}

		public IEnumerable<Customer> GetCustomers()
		{
			return _context.Customers;
			/*if(name == null)
			{
				return _context.Customers;
			}
			else
			{
				return _context.Customers.Where(c => c.FullName.Contains(name));
			}*/
		}
		
		public IEnumerable<Customer> SearchCustomerByName(string name)
		{
            return _context.Customers.Where(c => c.FullName.Contains(name));
        }

		public CustomerModel GetCustomer(int id)
		{
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                throw new DbUpdateException("Customer doesn't exist");
            }

            var convertedEntity = _customermapper.MapFromEntityToModel(customer);
            return convertedEntity;
        }


		public CustomerModel CreateCustomer(CustomerModel customer)
		{
			var checkCustomerName = _context.Customers.Any(p => p.FullName == customer.FullName);
			if (checkCustomerName)
			{
				throw new DbUpdateException($"Category with name {customer.FullName}, already exists.");
			}

			var convertedModel = _customermapper.MapFromModelToEntity(customer);

			_context.Customers.Add(convertedModel);
			_context.SaveChanges();

			return customer;
		}
		public void Delete(int id)
		{
			var customer = _context.Customers.Find(id);
			if(customer == null)
			{
				throw new DbUpdateException($"Category with id {id} doesn't exist.");
			}

			_context.Customers.Remove(customer);
			_context.SaveChanges();
		}

		public void UpdateCustomer(CustomerModel customer)
		{
			var customerToUpdate = _context.Customers.Find(customer.Id);
			if(customerToUpdate == null)
			{
				throw new DbUpdateException($"Customer with id {customer.Id} doesn't exist.");
			}

			customerToUpdate.FullName= customer.FullName;
			customerToUpdate.Email= customer.Email;
			customerToUpdate.Phone = customer.Phone;
			customerToUpdate.Etnicity= customer.Etnicity;
			customerToUpdate.DateOfBirth= customer.DateOfBirth;

			_context.SaveChanges();
		}

	}
}
