using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Factories
{
	public class FlatFactory : IFactory<Flat>
	{
		public Flat CreateDefaultObject()
		{
			return new Flat
			{
				CadastralNumber = "flat"
			};
		}
	}
}
