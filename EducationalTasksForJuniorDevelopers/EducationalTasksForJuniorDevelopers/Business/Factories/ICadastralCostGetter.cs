using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Factories
{
	public interface ICadastralCostGetter<in T>
	{
		decimal GetCadastralCost(T obj);
	}

	public class Test1 : ICadastralCostGetter<Flat>
	{
		public decimal GetCadastralCost(Flat obj)
		{
			return obj.CadastralCost;
		}
	}

	public class Test2 : ICadastralCostGetter<MarketObject>
	{
		public decimal GetCadastralCost(MarketObject obj)
		{
			return obj.CadastralCost;
		}
	}
}
