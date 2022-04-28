using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using RecycleApi.Models;

namespace RecycleApi.Authorization
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class RecycleAuthorizeAttribute : Attribute, IAuthorizationFilter
	{
		private readonly int _roleId;

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var user = context.HttpContext.Items["Client"] as ApiClientDtoOut;
			if (user == null)
			{
				// not logged in
				context.Result = new JsonResult(new {message = "Unauthorized"})
				{
					StatusCode = StatusCodes.Status401Unauthorized,
				};
			}
		}

		public RecycleAuthorizeAttribute(int roleId)
		{
			_roleId = roleId;
		}

		public RecycleAuthorizeAttribute()
		{
		}
	}
}