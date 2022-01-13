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

			var e = firstPriceFactor == secondPriceFactor;
			var f = firstPriceFactor.Equals(secondPriceFactor);
			var g = ReferenceEquals(firstPriceFactor, secondPriceFactor);
			var e1 = firstPriceFactor == thirdPriceFactor;
			var f1 = firstPriceFactor.Equals(thirdPriceFactor);
			var g1 = ReferenceEquals(firstPriceFactor, thirdPriceFactor);


			ChangePriceFactorDistanceToStop(new PriceFactor());

			ChangeMarketObjectSquare(new MarketObject());

			var type1 = CheckType(new MarketObject());
			var type2 = CheckType(new PriceFactor());
			var type3 = CheckType(1);
			var type4 = CheckType(new DateTime());

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

		private void ChangePriceFactorDistanceToStop(PriceFactor priceFactor)
		{
			priceFactor.DistanceToStop = 100;
		}

		private void ChangeMarketObjectSquare(MarketObject marketObject)
		{
			marketObject.Square = 100;
		}

		private string CheckType(object obj)
		{
			if (obj is MarketObject)
				return "ОН";

			if (obj is PriceFactor)
				return "Ценообразующий фактор";

			if (obj is int)
				return "Целочисленный тип";

			return "Неизвестный тип";
		}

		#endregion
	}
}
