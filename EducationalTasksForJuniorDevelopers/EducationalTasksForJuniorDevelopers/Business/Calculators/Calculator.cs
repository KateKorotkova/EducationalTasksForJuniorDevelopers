using System;
using System.Diagnostics;
using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Calculators
{
	public abstract class Calculator
	{
		private decimal _upksCorrectionCoefficient;
		public static int UpksCalculationCounter { get; set; }

		public delegate void GreateCadastralCostHandlerForNotification();
		public event GreateCadastralCostHandlerForNotification NotifyGreateCadastralCostHandler;

		private delegate void GreateCadastralCostDelegate(MarketObject marketObject);
		private GreateCadastralCostDelegate _chain;
		private Action<MarketObject> _builtInDelegate;


		static Calculator()
		{
			UpksCalculationCounter = -1;
		}

		public Calculator(decimal upksCorrectionCoefficient = 1)
		{
			_upksCorrectionCoefficient = upksCorrectionCoefficient;
			_chain += PrintCadatralNumber;
			_chain += PrintType;

			_builtInDelegate += PrintCadatralNumber;
			_builtInDelegate += PrintType;
		}


		public abstract decimal CalculateCadastralCost(MarketObject marketObject);


		public virtual decimal CalculateUpks(MarketObject obj)
		{
			UpksCalculationCounter++;

			var upks = (obj.CadastralCost / obj.Square) * _upksCorrectionCoefficient;

			if (upks > 1000000)
			{
				NotifyGreateCadastralCostHandler?.Invoke();
				_chain(obj);
				_builtInDelegate(obj);
			}

			return upks;
		}


		#region Support methods

		private void PrintCadatralNumber(MarketObject marketObject)
		{
			Debug.WriteLine(marketObject.CadastralNumber);
		}

		private void PrintType(MarketObject marketObject)
		{
			Debug.WriteLine(marketObject.Type);
		}

		#endregion
	}
}
