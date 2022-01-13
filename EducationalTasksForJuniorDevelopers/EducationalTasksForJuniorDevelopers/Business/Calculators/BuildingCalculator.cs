using System.Linq;
using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Calculators
{
	public sealed class BuildingCalculator : Calculator
	{
		public override decimal CalculateCadastralCost(MarketObject marketObject)
		{
			return (marketObject as Building).Flats.Sum(x => x.CadastralCost);
		}

		protected override decimal CalculateUpks(MarketObject marketObject)
		{
			return (marketObject as Building).Flats.Sum(x => x.Upks);
		}
	}
}
