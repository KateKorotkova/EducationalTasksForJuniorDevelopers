using EducationalTasksForJuniorDevelopers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
			var firstFlat = new Flat { CadastralNumber = "a" };
			var secondFlat = new Flat { CadastralNumber = "b" };
			var flats = new List<Flat> { firstFlat, secondFlat };
			var firstStr = GetCadastralNumbersViaConcat(flats);
			var secondStr = GetCadastralNumbersViaStringBuilder(flats);

			GetFlatByCadastralNumber(flats, "A");

			var encoded = EncodeCadastralNumber(firstFlat.CadastralNumber);
			var decoded = DecodeCadastralNumber(encoded);

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

		private string GetCadastralNumbersViaConcat(List<Flat> flats)
		{
			var cadastralNumbers = string.Empty;

			flats.ForEach(x => cadastralNumbers += $"'{x.CadastralNumber}', ");

			return cadastralNumbers;
		}

		private string GetCadastralNumbersViaStringBuilder(List<Flat> flats)
		{
			var cadastralNumbers = new StringBuilder();

			flats.ForEach(x => cadastralNumbers.Append(x.CadastralNumber).Append(","));

			return cadastralNumbers.ToString();
		}

		private void GetFlatByCadastralNumber(List<Flat> flats, string cadastralNumber)
		{
			var a = flats.FirstOrDefault(x => x.CadastralNumber.Equals(cadastralNumber, StringComparison.InvariantCultureIgnoreCase));
			var b = flats.FirstOrDefault(x => x.CadastralNumber.Equals(cadastralNumber, StringComparison.CurrentCultureIgnoreCase));
			var c = flats.FirstOrDefault(x => x.CadastralNumber.Equals(cadastralNumber, StringComparison.OrdinalIgnoreCase));
		}

		private byte[] EncodeCadastralNumber(string cadastralNumber)
		{
			var encodingUTF8 = Encoding.UTF8;
			return encodingUTF8.GetBytes(cadastralNumber);
		}

		private string DecodeCadastralNumber(byte[] cadastralNumberBytes)
		{
			return Encoding.UTF8.GetString(cadastralNumberBytes);
		}

		#endregion
	}
}
