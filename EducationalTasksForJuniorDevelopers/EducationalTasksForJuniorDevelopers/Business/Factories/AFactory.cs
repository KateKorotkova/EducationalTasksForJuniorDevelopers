using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Factories
{
	public abstract class AFactory<T> where T : MarketObject
	{
		public abstract T CreateDefaultObject();
	}
}
