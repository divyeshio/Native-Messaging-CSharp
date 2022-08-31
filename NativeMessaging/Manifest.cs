using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NativeMessaging
{
    internal class Manifest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("path")]
        public string ExecuteablePath { get; set; }

        [JsonPropertyName("type")]
        public string Type { get { return "stdio"; } }

        [JsonPropertyName("allowed_origins")]
        public string[] AllowedOrigins { get; set; }

        public Manifest(
            string hostname,
            string description,
            string executeablePath,
            string[] allowedOrigins)
        {
            Name = hostname;
            Description = description;
            AllowedOrigins = allowedOrigins;
            ExecuteablePath = executeablePath;
        }
    }
}
