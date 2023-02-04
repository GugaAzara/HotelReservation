using HotelReservation.Entities;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Dynamic;

namespace HotelReservation.Controllers
{
	public class ReservationController : Controller
	{
		private readonly ILogger<ReservationController> _logger;
		public readonly IReservationService _reservationService;
		public readonly ICustomerService _customerService;
		public readonly IRoomService _roomService;

		public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService, ICustomerService customerService, IRoomService roomService)
		{
			_roomService = roomService;
			_logger = logger;
			_reservationService = reservationService;
			_customerService = customerService;
		}
		
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}



		public IActionResult GetReservations()
		{
			var allReservations = _reservationService.GetReservations();
			return View(allReservations);
		}

        public IActionResult GetCustomers()
		{
            var AllCostumers = _customerService.GetCustomers();
            return View(AllCostumers);
        }


        public IActionResult Create()
		{
			var allCustomer = _customerService.GetCustomers();
			var allRoom = _roomService.GetRooms();

			var newReservationModel = new ReservationModel();
            newReservationModel.CustomerSelectList = new List<SelectListItem>();
            newReservationModel.RoomSelectList = new List<SelectListItem>();
			
			
			foreach (var customer in allCustomer)
			{
				newReservationModel.CustomerSelectList.Add(new SelectListItem { Text = customer.FullName, Value = customer.Id.ToString() });
			}

			foreach (var room in allRoom)
			{
				newReservationModel.RoomSelectList.Add(new SelectListItem { Text = room.RoomNumber, Value = room.Id.ToString()});
			}

            return View(newReservationModel);
		}

		[HttpPost]
		public IActionResult Create(ReservationModel reservation)
		{
			if(ModelState.IsValid)
			{
				_reservationService.CreateReservation(reservation);
                return RedirectToAction("GetReservations");
            }
			return View(reservation);

		}

		public IActionResult ShowpopUp()
		{
			var allCustomers = _customerService.GetCustomers(); 

			//specify the name or path of the partial view
			return PartialView("CustomerPopup", allCustomers);
		}

		public IActionResult Edit(int id)
		{
			var reservationToEdit = _reservationService.GetReservation(id);

			var allCustomer = _customerService.GetCustomers();
			var allRoom = _roomService.GetRooms();

			var newReservationModel = new ReservationModel();
			newReservationModel.CustomerSelectList = new List<SelectListItem>();
			newReservationModel.RoomSelectList = new List<SelectListItem>();

			foreach (var customer in allCustomer)
			{

				newReservationModel.CustomerSelectList.Add(new SelectListItem { Text = customer.FullName, Value = customer.Id.ToString() });
			}

			foreach (var room in allRoom)
			{
				newReservationModel.RoomSelectList.Add(new SelectListItem { Text = room.RoomNumber, Value = room.Id.ToString() });
			}

			ViewBag.NewReservationModel = newReservationModel;
			/*ViewBag.reservationToEdit = reservationToEdit;*/

			return View(reservationToEdit);
		}
		public IActionResult Update(ReservationModel reservation)
		{
			if(ModelState.IsValid)
			{
				_reservationService.UpdateReservation(reservation);
				return RedirectToAction("GetReservations");
			}

			return View(reservation);
		}
	


	}
}
