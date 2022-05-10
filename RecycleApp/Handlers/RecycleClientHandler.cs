using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace RecycleApp.Handlers
{
	public class RecycleClientHandler : HttpClientHandler
	{
		private static readonly string AuthorizationHeader = HeaderNames.Authorization;

		private const string AuthorizationScheme = "Bearer";

		protected override Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request,
			CancellationToken cancellationToken
		)
		{
			if (App.CurrentUser != null)
			{
				request.Headers.Add(AuthorizationHeader, $"{AuthorizationScheme} {App.CurrentUser.Token}" );
			}

			return base.SendAsync(request, cancellationToken);
		}
	}
}