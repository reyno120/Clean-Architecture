using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Presentation.Helpers
{
    public interface IWebApiHelper
    {
        string GetApi(string route);
        string PostApi<T>(string route, T postObject);
    }

    public static class HttpClientExtensionMethods
    {
        public static void ConfigureApiClient(this HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }


    public class WebApiHelper : IWebApiHelper
    {
        private readonly IConfiguration _configuration;
        public WebApiHelper(IConfiguration configuration) 
        {
            _configuration = configuration;
        }


        private string BuildUrl(string route)
        {
            return _configuration.GetConnectionString("Server") + route;
        }

        public string GetApi(string route)
        {
            route = BuildUrl(route);

            using (HttpClient client = new HttpClient())
            {
                client.ConfigureApiClient();
                var response = client.GetAsync(route).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;

                throw new Exception(response.ReasonPhrase);
            }
        }

        public string PostApi<T>(string route, T postObject)
        {
            route = BuildUrl(route);

            using (HttpClient client = new HttpClient())
            {
                client.ConfigureApiClient();
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(postObject), Encoding.UTF8, "application/json");
                var response = client.PostAsync(route, httpContent).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;

                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
