using EducationalTasksForJuniorDevelopers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EducationalTasksForJuniorDevelopers.Attributes;
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

		[UserRightsChecker(Tag = "Admin")]
		public IActionResult Index()
		{
			var flatCalculator = new FlatCalculator();

			var type1 = flatCalculator.GetType();
			var type2 = typeof(FlatCalculator);

			var objViaEmptyConstructor = (FlatCalculator)Activator.CreateInstance(typeof(FlatCalculator));
			var objViaConstructorWithParameter = (FlatCalculator)Activator.CreateInstance(typeof(FlatCalculator), 1m);

			var methodInfo = typeof(FlatCalculator).GetMethod(nameof(FlatCalculator.CalculateCadastralCost));
			var cadastralCost = methodInfo.Invoke(flatCalculator, new[] {new MarketObject { CadastralCost = 100 }});

			var prop = flatCalculator.GetType().GetProperty(nameof(FlatCalculator.TestReflection));
			prop.SetValue(flatCalculator, "b", null);

			return View();
		}

		[UserRightsChecker(Tag = "SimpleUser")]
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
