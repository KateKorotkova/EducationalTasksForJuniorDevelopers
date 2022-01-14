using System;
using System.Diagnostics;
using EducationalTasksForJuniorDevelopers.Business.Calculators.Exceptions;
using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Calculators
{
	public abstract class Calculator : IDisposable
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

		public void Dispose()
		{

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

		public int? Subtraction(int numberFrom, int? amount)
		{
			return numberFrom - amount;
		}

		public int? Subtraction(int? numberFrom, int amount)
		{
			return numberFrom - amount;
		}

		public bool Compare(int first, int? second)
		{
			return first > second;
		}

		public bool Compare(int? first, int second)
		{
			return first > second;
		}

		public decimal? Divide(decimal firstNumber, decimal secondNumber)
		{
			try
			{
				if (secondNumber == 0)
					throw new ZeroInputParameterException();

				var result = firstNumber / secondNumber;

				return result;
			}
			catch (OverflowException e)
			{
				Debug.WriteLine("В ходе расчетов получилось слишком большое или слишком маленькое число");
				return null;
			}
			catch (ZeroInputParameterException e)
			{
				Debug.WriteLine("Делитель не может быть равным нулю");
				return null;
			}
		}

		#endregion
	}
}
