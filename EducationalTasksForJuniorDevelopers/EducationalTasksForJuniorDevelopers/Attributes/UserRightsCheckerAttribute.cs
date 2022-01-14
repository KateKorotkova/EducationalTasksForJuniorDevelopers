using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EducationalTasksForJuniorDevelopers.Attributes
{
	public class UserRightsCheckerAttribute : ActionFilterAttribute
	{
		public string Tag { get; set; }

		public override void OnActionExecuted(ActionExecutedContext context)
		{
			if (Tag == "Admin")
				Debug.WriteLine("Доступ к админской функции");

			base.OnActionExecuted(context);
		}
	}
}
