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

		public static bool operator ==(MarketObject first, MarketObject second)
		{
			if (first is null || second is null)
				return false;

			return first.CadastralNumber == second.CadastralNumber;
		}

		public static bool operator !=(MarketObject first, MarketObject second)
		{
			if (first is null || second is null)
				return false;

			return first.CadastralNumber != second.CadastralNumber;
		}

		public override bool Equals(object obj)
		{
			var second = obj as MarketObject;
			if (obj is null)
				return false;

			if (ReferenceEquals(this, obj))
				return true;

			return CadastralNumber == second.CadastralNumber;
		}
	}
}
