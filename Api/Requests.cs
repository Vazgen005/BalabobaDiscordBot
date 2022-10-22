using Newtonsoft.Json;
using System.Text;

namespace BalabobaDiscordBot.Api
{
    public class BalabobaRequests
    {
        static public readonly HttpClient client = new();

        static public async Task<BalabobaIntros> GetBalabobaIntros(string intro)
        {
            var response = await client.GetAsync(intro);

            return JsonConvert.DeserializeObject<BalabobaIntros>(await response.Content.ReadAsStringAsync());
        }

        public static async Task<BalabobaRequestResult> GetBalabobaString(string query, int filter = 1, long intro = 0)
        {

            var data = JsonConvert.SerializeObject(new Dictionary<string, dynamic>
            {
                { "filter", filter },
                { "intro", intro },
                { "query", query }
            });

            var response = await client.PostAsync("https://yandex.ru/lab/api/yalm/text3", new StringContent(data, Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<BalabobaRequestResult>(await response.Content.ReadAsStringAsync());
        }
    }
}
