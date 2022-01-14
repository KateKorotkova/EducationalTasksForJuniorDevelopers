﻿using EducationalTasksForJuniorDevelopers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			var buildingCalculator = new BuildingCalculator();
			var a = buildingCalculator.Subtraction(10, null);
			var b = buildingCalculator.Subtraction(null, 10);

			var c = buildingCalculator.Compare(10, null);
			var d = buildingCalculator.Compare(null, 10);

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
