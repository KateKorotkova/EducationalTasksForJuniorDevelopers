using EducationalTasksForJuniorDevelopers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var a = CheckInputParameterType(new MarketObject());
			var b = CheckInputParameterType(new Building());
			var c = CheckInputParameterType(new Flat());

			//ProcessFlat(new MarketObject());
			//ProcessFlat(new Building());
			//ProcessFlat(new Flat());

			CastToBaseObject(new MarketObject());
			CastToBaseObject(new Building());
			CastToBaseObject(new Flat());

			CastToFlat(new MarketObject());
			CastToFlat(new Building());
			CastToFlat(new Flat());

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


		#region Support Methods

		private string CheckInputParameterType(MarketObject marketObject)
		{
			var type = string.Empty;

			if (marketObject is MarketObject)
				type = nameof(MarketObject);

			if (marketObject is Building)
				type = nameof(Building);

			if (marketObject is Flat)
				type = nameof(Flat);

			return $"Тип входного параметра - {type}";
		}

		private void ProcessFlat(Flat flat)
		{

		}

		private void CastToBaseObject(object obj)
		{
			var a = obj as MarketObject;
			var b = (MarketObject) obj;
		}

		private void CastToFlat(object obj)
		{
			var a = obj as Flat;
			var b = (Flat) obj;
		}

		#endregion
	}
}
