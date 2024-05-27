using System.Net.Http.Json;
using Api.IsTempMail.Model;

namespace Api.IsTempMail.Service
{
    public class IsTempMailService : IIsTempMailService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string IsTempMail_Key;
        private readonly string IsTempMail_Url = "https://istempmail.com/api/check/API_TOKEN/";

        public IsTempMailService(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;

            IsTempMail_Key = Environment.GetEnvironmentVariable("ISTEMPMAIL_KEY")
                ?? throw new InvalidOperationException("The environment variable 'ISTEMPMAIL_KEY' is not set or is empty.");

            IsTempMail_Url = IsTempMail_Url.Replace("API_TOKEN", IsTempMail_Key);
        }

        public async Task<Domain> CheckEmailProviderOnline(string domain)
        {
            return await _clientFactory.CreateClient().GetFromJsonAsync<Domain>(IsTempMail_Url + domain) 
                ?? throw new Exception();
        }
    }
}