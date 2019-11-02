using Newtonsoft.Json;

namespace CalculatorServer.Model
{
    internal sealed class ServerData
    {
        #region Properties
        [JsonProperty]
        public string Host { get; set; }
        [JsonProperty]
        public int Port { get; set; }
        #endregion
    }
}
