using Microsoft.AspNetCore.Mvc;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using System.Xml.Linq;

namespace HotelReservation.Controllers
{
	public class CustomerController : Controller
	{
		public readonly ICustomerService _customerService;

		public CustomerController(ICustomerService costumerService)
		{
			_customerService = costumerService;
		}

		public IActionResult GetCustomers()
		{
			var AllCostumers = _customerService.GetCustomers();
			return View(AllCostumers);
		}
		
		public IActionResult SearchCustomerByName(string name)
		{
			var searchedCustomers = _customerService.SearchCustomerByName(name);
			return View("GetCustomers", searchedCustomers);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CustomerModel category) 
		{ 
			if(ModelState.IsValid)
			{
				_customerService.CreateCustomer(category);
				return RedirectToAction("GetCustomers");
			}

			return View(category);
		}


		public IActionResult Edit(int id)
		{
			var CustomerToGet = _customerService.GetCustomer(id);
			return View(CustomerToGet);
		}


		[HttpPost]
		public IActionResult Delete(int id)
		{
			_customerService.Delete(id);
			
			return Redirect("GetCustomers");
		}

		[HttpPost]
		public IActionResult Update(CustomerModel customer)
		{
			if (ModelState.IsValid)
			{
				_customerService.UpdateCustomer(customer);
				return RedirectToAction("GetCustomers");
			}

			return View(customer);
		}
	}
}
