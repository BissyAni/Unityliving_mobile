using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public   class TokenModel
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        [JsonProperty(PropertyName = "user_details")]
        public UserModel UserDetails { get; set; }
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
        [JsonProperty(PropertyName = "error_msg")]
        public string ErrorMessage { get; set; }
    }
}
