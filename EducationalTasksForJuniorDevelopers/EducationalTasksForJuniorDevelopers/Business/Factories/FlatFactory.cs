using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Factories
{
	public class FlatFactory : AFactory<Flat>
	{
		public override Flat CreateDefaultObject()
		{
			return new Flat
			{
				CadastralNumber = "flat"
			};
		}
	}
}
