using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Calculators
{
	public abstract class Calculator
	{
		private decimal _upksCorrectionCoefficient;
		public static int UpksCalculationCounter { get; set; }


		static Calculator()
		{
			UpksCalculationCounter = -1;
		}

		public Calculator()
		{
			_upksCorrectionCoefficient = 1;
		}

		public Calculator(decimal upksCorrectionCoefficient)
		{
			_upksCorrectionCoefficient = upksCorrectionCoefficient;
		}


		public abstract decimal CalculateCadastralCost(MarketObject marketObject);

		protected virtual decimal CalculateUpks(MarketObject obj)
		{
			UpksCalculationCounter++;

			return (obj.CadastralCost / obj.Square) * _upksCorrectionCoefficient;
		}
	}
}
