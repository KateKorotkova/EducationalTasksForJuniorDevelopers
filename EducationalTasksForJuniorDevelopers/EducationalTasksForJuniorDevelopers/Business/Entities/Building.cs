using System.Collections.Generic;
using EducationalTasksForJuniorDevelopers.Attributes;

namespace EducationalTasksForJuniorDevelopers.Business.Entities
{
	[Custom]
	public class Building : MarketObject
	{
		public List<Flat> Flats { get; set; }

		public Flat this[int n] => Flats[n];
	}
}
