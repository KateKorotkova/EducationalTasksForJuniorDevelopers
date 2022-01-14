using EducationalTasksForJuniorDevelopers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
			var binaryFormatter = new BinaryFormatter();
			var memoryStream = new MemoryStream();

			var sp = new SquarePower(20);
			binaryFormatter.Serialize(memoryStream, sp);
			memoryStream.Position = 0;
			sp = binaryFormatter.Deserialize(memoryStream) as SquarePower;

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

		[Serializable]
		class SquarePower : ISerializable
		{
			public int Number;

			[NonSerialized]
			public  int Square;

			public SquarePower(int number)
			{
				Number = number;
				Square = Number * Number;
			}

			public void GetObjectData(SerializationInfo info, StreamingContext context)
			{
				info.AddValue(nameof(Number), Number);
			}

			public SquarePower(SerializationInfo info, StreamingContext context)
			{
				Number = (int)info.GetValue(nameof(Number), typeof(int));

				Square = Number * Number;
			}
		}
	}
}
