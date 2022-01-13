using EducationalTasksForJuniorDevelopers.Business.Entities;

namespace EducationalTasksForJuniorDevelopers.Business.Helpers
{
	public static class StringExtensions
	{
		public static string MapCadastralNumber(this MarketObject marketObject)
		{
			return $"Кадастровый номер - ‘{marketObject.CadastralNumber}’";
		}
	}
}
