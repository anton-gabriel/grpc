using Newtonsoft.Json;

namespace CalculatorServer.Model
{
    internal sealed class Settings
    {
        [JsonProperty]
        public ServerData ServerData { get; set; }
        [JsonProperty]
        public string LoggingFile { get; set; }
    }
}
