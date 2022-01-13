using EducationalTasksForJuniorDevelopers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EducationalTasksForJuniorDevelopers.Business.Entities;
using EducationalTasksForJuniorDevelopers.Business.Helpers;

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
			var firstPriceFactor = new PriceFactor();
			PriceFactor secondPriceFactor;
			ChangePriceFactorDistanceToStopVia(ref firstPriceFactor, out secondPriceFactor);
			var a = firstPriceFactor;
			var b = secondPriceFactor;


			var firstMarketObject = new MarketObject();
			MarketObject secondMarketObject;
			ChangeMarketObjectCadastralNumber(ref firstMarketObject, out secondMarketObject);

			var summaryCost = CalculateSummaryCadastralCost(new MarketObject{CadastralCost = 1}, new MarketObject{CadastralCost = 2});

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

		private void ChangePriceFactorDistanceToStopVia(ref PriceFactor firstPriceFactor, out  PriceFactor secondPriceFactor)
		{
			firstPriceFactor.DistanceToStop = 100;

			secondPriceFactor = new PriceFactor { DistanceToStop = 200 };
		}

		private void ChangeMarketObjectCadastralNumber(ref MarketObject firstMarketObject, out MarketObject secondMarketObject)
		{
			firstMarketObject.CadastralNumber = "1";

			secondMarketObject = new MarketObject { CadastralNumber = "2" };
		}

		private decimal CalculateSummaryCadastralCost(params MarketObject[] marketObjects)
		{
			return marketObjects.Sum(x => x.CadastralCost);
		}

		#endregion
	}
}
