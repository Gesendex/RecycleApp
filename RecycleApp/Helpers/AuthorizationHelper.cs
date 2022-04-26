using RecycleApp.Models;

namespace RecycleApp.Helpers
{
	public static class AuthorizationHelper
	{
		public static AuthorizationBodyDtoIn GetAuthorizationModel(
			string email,
			string password
		)
		{
			if (!FieldValidationHelper.IsValidEmail(email) || string.IsNullOrWhiteSpace(email))
				return null;
			if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
				return null;

			return new AuthorizationBodyDtoIn(
				email: email,
				password: password
			);
		}
	}
}