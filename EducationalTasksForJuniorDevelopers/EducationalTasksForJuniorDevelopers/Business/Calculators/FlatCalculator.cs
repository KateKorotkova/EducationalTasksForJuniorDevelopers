using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Calculators
{
	public sealed class FlatCalculator : Calculator
	{
		private readonly decimal _cadastralCostCorrectionCoefficient;
		private const decimal _upksCorrectionCoefficient = 0.9m;


		public FlatCalculator(decimal cadastralCostCorrectionCoefficient)
		{
			_cadastralCostCorrectionCoefficient = cadastralCostCorrectionCoefficient;
		}


		public override decimal CalculateCadastralCost(MarketObject marketObject)
		{
			return marketObject.CadastralCost * _cadastralCostCorrectionCoefficient;
		}

		protected override decimal CalculateUpks(MarketObject obj)
		{
			var initialUpks = base.CalculateUpks(obj);

			return initialUpks * _upksCorrectionCoefficient;
		}
	}
}
