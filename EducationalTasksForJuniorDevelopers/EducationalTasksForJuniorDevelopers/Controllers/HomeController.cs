using EducationalTasksForJuniorDevelopers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EducationalTasksForJuniorDevelopers.Business.Calculators;
using EducationalTasksForJuniorDevelopers.Business.Entities;
using EducationalTasksForJuniorDevelopers.Business.Factories;
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
			var buildingFactory = new BuildingFactory();
			var flatFactory = new FlatFactory();

			FactoryManager(buildingFactory, flatFactory);

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

		private void FactoryManager(params IFactory<MarketObject>[] factories)
		{
			var allObjects = new List<MarketObject>();

			factories.ToList().ForEach(x =>
			{
				var obj = x.CreateDefaultObject();
				allObjects.Add(obj);
			});
		}

		#endregion
	}
}
