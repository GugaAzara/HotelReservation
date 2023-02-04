using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
	public class RoomController : Controller
	{
		public readonly IRoomService _roomService;

		public RoomController(IRoomService roomService)
		{
			_roomService = roomService;
		}

		public IActionResult GetRooms()
		{
			var AllRooms = _roomService.GetRooms();
			return View(AllRooms);
		}

		public IActionResult GetRoomsByNumber(string name)
		{
			var SearchedRooms = _roomService.GetRoomsByNumber(name);
			return View("GetRooms", SearchedRooms);
		}


		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(RoomModel room)
		{
			if (ModelState.IsValid)
			{
				_roomService.CreateRoom(room);
				return RedirectToAction("GetRooms");
			}

			return View(room);
		}

		public IActionResult Edit(int id)
		{
			var SelectedRoom = _roomService.GetRoom(id);
			return View(SelectedRoom);
		}

		[HttpPost]
		public IActionResult Update(RoomModel room)
		{
			if (ModelState.IsValid)
			{
				_roomService.UpdateRoom(room);
				return RedirectToAction("GetRooms");
			}

			return View(room);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			_roomService.DeleteRoom(id);
			return RedirectToAction("GetRooms");
		}
	}
}
