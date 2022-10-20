using Newtonsoft.Json;
using System.Text;

namespace BalabobaDiscordBot
{
    public class BalabobaRequests
    {
        static public readonly HttpClient client = new();
        static public async Task<BalabobaRequestResult> GetBalabobaString(string query, int filter = 1, int intro = 0)
        {
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            var data = JsonConvert.SerializeObject(new Dictionary<string, dynamic>
            {
                { "filter", filter },
                { "intro", intro },
                { "query", query }
            });

            var response = await client.PostAsync("https://yandex.ru/lab/api/yalm/text3", new StringContent(data, Encoding.UTF8, "application/json"));

            var responseString = await response.Content.ReadAsStringAsync();

            dynamic? deserialized = JsonConvert.DeserializeObject(responseString);

            return new BalabobaRequestResult()
            {
                BadQuery = deserialized["bad_query"],
                EmptyZeliboba = deserialized["empty_zeliboba"],
                Error = deserialized["error"],
                Intro = deserialized["intro"],
                IsCached = deserialized["is_cached"],
                Query = deserialized["query"],
                Signature = deserialized["signature"],
                Text = deserialized["text"]
            };
        }
    }
}
