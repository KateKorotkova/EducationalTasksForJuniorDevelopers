using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Calculators
{
	public abstract class Calculator
	{
		public static int UpksCalculationCounter { get; set; }

		public abstract decimal CalculateCadastralCost(MarketObject marketObject);


		protected virtual decimal CalculateUpks(MarketObject obj)
		{
			UpksCalculationCounter++;

			return obj.CadastralCost / obj.Square;
		}
	}
}
