using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Factories
{
	public class BuildingFactory : AFactory<Building>
	{
		public override Building CreateDefaultObject()
		{
			return new Building
			{
				CadastralNumber = "building"
			};
		}
	}
}
