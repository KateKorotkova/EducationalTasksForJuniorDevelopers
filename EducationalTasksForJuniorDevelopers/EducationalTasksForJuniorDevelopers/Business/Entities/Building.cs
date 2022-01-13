using System.Collections.Generic;

namespace EducationalTasksForJuniorDevelopers.Business.Entities
{
	public class Building : MarketObject
	{
		public List<Flat> Flats { get; set; }

		public Flat this[int n] => Flats[n];
	}
}
