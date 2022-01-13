using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Calculators
{
	public abstract class Calculator
	{
		private decimal _upksCorrectionCoefficient;
		public static int UpksCalculationCounter { get; set; }

		public delegate void GreateCadastralCostHandlerForNotification();
		public event GreateCadastralCostHandlerForNotification NotifyGreateCadastralCostHandler;


		static Calculator()
		{
			UpksCalculationCounter = -1;
		}

		public Calculator(decimal upksCorrectionCoefficient = 1)
		{
			_upksCorrectionCoefficient = upksCorrectionCoefficient;
		}


		public abstract decimal CalculateCadastralCost(MarketObject marketObject);


		public virtual decimal CalculateUpks(MarketObject obj)
		{
			UpksCalculationCounter++;

			var upks = (obj.CadastralCost / obj.Square) * _upksCorrectionCoefficient;

			if (upks > 1000000)
			{
				NotifyGreateCadastralCostHandler?.Invoke();
			}

			return upks;
		}
	}
}
