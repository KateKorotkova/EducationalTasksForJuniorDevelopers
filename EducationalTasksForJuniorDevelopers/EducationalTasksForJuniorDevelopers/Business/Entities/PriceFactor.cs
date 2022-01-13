namespace EducationalTasksForJuniorDevelopers.Business.Entities
{
	public struct PriceFactor
	{
		public long MarketObjectId { get; set; }
		public string WallMaterial { get; set; }
		public decimal DistanceToStop { get; set; }

		public static bool operator ==(PriceFactor first, PriceFactor second)
		{
			return first.MarketObjectId == second.MarketObjectId;
		}

		public static bool operator !=(PriceFactor first, PriceFactor second)
		{
			return first.MarketObjectId != second.MarketObjectId;
		}

		public override bool Equals(object second)
		{
			if (!(second is PriceFactor))
				return false;

			return MarketObjectId == ((PriceFactor)second).MarketObjectId;
		}
	}
}
