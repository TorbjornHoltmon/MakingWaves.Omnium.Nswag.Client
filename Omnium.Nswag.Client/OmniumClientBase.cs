using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Omnium.Nswag.Client
{
    public abstract class OmniumClientBase
    {
        private readonly IOmniumClientBaseSettings _settings;

        protected OmniumClientBase(IOmniumClientBaseSettings settings)
        {
            _settings = settings;
        }

        private IConfiguration Configuration => _settings.Configuration;
        private string? AccessToken
        {
            get => _settings.AccessToken;
            set => _settings.AccessToken = value;
        }
        private DateTimeOffset Expiration
        {
            get => _settings.Expiration;
            set => _settings.Expiration = value;
        }

        public async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var message = new HttpRequestMessage();
            message.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", await GetAccessToken(cancellationToken));
            return message;
        }

        private async Task<string> GetAccessToken(CancellationToken cancellationToken)
        {
            if (AccessToken == null || DateTimeOffset.UtcNow > Expiration)
            {
                AccessToken = await RequestAccessToken(cancellationToken);

                Expiration = DateTimeOffset.UtcNow.AddDays(9);

                return AccessToken;
            }

            return AccessToken;
        }

        private async Task<string> RequestAccessToken(CancellationToken cancellationToken)
        {
            string tokenPath = $"/api/Token";
            using var client = new HttpClient();
            client.BaseAddress = new Uri(Configuration["Omnium:BaseAddress"]);
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("clientId", Configuration["Omnium:ClientId"]),
                new KeyValuePair<string, string>("clientSecret", Configuration["Omnium:ClientSecret"])
            });

            //Get Token
            var response = await client.PostAsync(tokenPath, formContent, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Get token failed! Status: {response.StatusCode}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}