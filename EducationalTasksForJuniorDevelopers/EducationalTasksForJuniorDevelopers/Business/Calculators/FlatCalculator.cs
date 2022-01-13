using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Calculators
{
	public sealed class FlatCalculator : Calculator
	{
		private decimal _cadastralCostCorrectionCoefficient;


		public FlatCalculator(decimal cadastralCostCorrectionCoefficient)
		{
			_cadastralCostCorrectionCoefficient = cadastralCostCorrectionCoefficient;
		}


		public override decimal CalculateCadastralCost(MarketObject marketObject)
		{
			return marketObject.CadastralCost * _cadastralCostCorrectionCoefficient;
		}
	}
}
