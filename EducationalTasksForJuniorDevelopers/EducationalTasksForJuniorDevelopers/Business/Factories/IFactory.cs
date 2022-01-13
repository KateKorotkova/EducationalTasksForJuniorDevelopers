namespace EducationalTasksForJuniorDevelopers.Business.Factories
{
	public interface IFactory<out T>
	{
		T CreateDefaultObject();
	}
}
