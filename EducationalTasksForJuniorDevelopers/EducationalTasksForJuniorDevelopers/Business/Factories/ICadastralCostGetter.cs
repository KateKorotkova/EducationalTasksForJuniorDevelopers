using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Factories
{
	public interface ICadastralCostGetter<in T>
	{
		decimal GetCadastralCost(T obj);
	}

	public class FlatCadastralCostGetter : ICadastralCostGetter<Flat>
	{
		public decimal GetCadastralCost(Flat obj)
		{
			return obj.CadastralCost;
		}
	}

	public class MarketObjectCadastralCostGetter : ICadastralCostGetter<MarketObject>
	{
		public decimal GetCadastralCost(MarketObject obj)
		{
			return obj.CadastralCost;
		}
	}
}
