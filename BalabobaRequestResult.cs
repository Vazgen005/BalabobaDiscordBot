using Newtonsoft.Json;

namespace BalabobaDiscordBot
{
    public struct BalabobaRequestResult
    {
        [JsonProperty(PropertyName = "bad_query")]
        public int? BadQuery;
        [JsonProperty(PropertyName = "empty_zeliboba")]
        public int? EmptyZeliboba;
        public int? Error;
        public int? Intro;
        [JsonProperty(PropertyName = "is_cached")]
        public int? IsCached;
        public string? Query;
        public string? Signature;
        public string? Text;
    }
}
