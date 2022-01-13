using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Factories
{
	public class BuildingFactory : IFactory<Building>
	{
		public Building CreateDefaultObject()
		{
			return new Building
			{
				CadastralNumber = "building"
			};
		}
	}
}
