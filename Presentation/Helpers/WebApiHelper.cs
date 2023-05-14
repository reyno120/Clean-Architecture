using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Presentation.Helpers
{
    public static class WebApiHelper
    {
        private static string BuildUrl(string route)
        {
            string baseRoute = "https://localhost:7070";
            return baseRoute + route;
        }

        private static void ConfigureApiClient(this HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static string GetApi(string route)
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

        public static string PostApi<T>(string route, T postObject)
        {
            route = BuildUrl(route);

            using (HttpClient client = new HttpClient())
            {
                client.ConfigureApiClient();
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(postObject));
                var response = client.PostAsync(route, httpContent).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;

                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
