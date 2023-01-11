using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelReservation.Controllers
{
	public class ReservationController : Controller
	{
		private readonly ILogger<ReservationController> _logger;

		public ReservationController(ILogger<ReservationController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
