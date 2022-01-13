namespace EducationalTasksForJuniorDevelopers.Business.Factories
{
	public interface IFactory<T>
	{
		T CreateDefaultObject();
	}
}
