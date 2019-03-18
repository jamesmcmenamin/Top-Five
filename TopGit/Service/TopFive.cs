using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TopGit.Models;

namespace TopGit.Service
{
    public class TopFive
    {
        public async Task<Repository> GetTopFive(string language)
        {
            var url = "https://api.github.com/search/repositories?&q="+language+"&sort=stars&order=desc&page=1&per_page=5&type=Repositories";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    using (var httpResponseMessage =
                        await client.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead))
                    {
                        var response = httpResponseMessage.EnsureSuccessStatusCode();
                        var result = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<Repository>(result);

                    }
                }
            }
        }
    }
}
