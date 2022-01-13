using System.Collections.Generic;

namespace EducationalTasksForJuniorDevelopers.Business.Entities
{
	public class MarketObject
	{
		public long Id { get; set; }
		public Type Type { get; set; }
		public string CadastralNumber { get; set; }
		public decimal Square { get; set; }
		public decimal CadastralCost { get; set; }
		public decimal Upks { get; set; }
	}
}
