using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace NativeMessaging
{
    internal class ResponseConfirmation
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public JsonObject Data { get; set; }

        public ResponseConfirmation(JsonObject data)
        {
            Data = data;
            Message = "Confirmation of received data";
        }

        public JsonObject? GetJsonObject()
        {
            return JsonSerializer.Deserialize<JsonObject>(
                JsonSerializer.Serialize(this));
        }
    }
}