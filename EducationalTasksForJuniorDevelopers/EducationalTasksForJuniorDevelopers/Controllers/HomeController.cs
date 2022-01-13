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
			var firstMarketObject = new MarketObject { CadastralNumber = "1" };
			var secondMarketObject = new MarketObject { CadastralNumber = "1" };
			var thirdMarketObject = new MarketObject { CadastralNumber = "2" };

			var a = firstMarketObject == secondMarketObject;
			var b = firstMarketObject.Equals(secondMarketObject);
			var c = ReferenceEquals(firstMarketObject, secondMarketObject);
			var a1 = firstMarketObject == thirdMarketObject;
			var b1 = firstMarketObject.Equals(thirdMarketObject);
			var c1 = ReferenceEquals(firstMarketObject, thirdMarketObject);

			var firstPriceFactor = new PriceFactor { MarketObjectId = 1 };
			var secondPriceFactor = new PriceFactor { MarketObjectId = 1 };
			var thirdPriceFactor = new PriceFactor { MarketObjectId = 2 };

			//var e = firstPriceFactor == secondPriceFactor;
			var f = firstMarketObject.Equals(secondPriceFactor);
			var g = ReferenceEquals(firstPriceFactor, secondPriceFactor);
			//var e1 = firstPriceFactor == thirdPriceFactor;
			var f1 = firstPriceFactor.Equals(thirdPriceFactor);
			var g1 = ReferenceEquals(firstPriceFactor, thirdPriceFactor);

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



		#endregion
	}
}
