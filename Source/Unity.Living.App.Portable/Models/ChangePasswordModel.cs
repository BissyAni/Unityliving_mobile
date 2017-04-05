using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public class ChangePasswordModel
    {
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "password2")]
        public string Password2 { get; set; }
        [JsonProperty(PropertyName = "currentpassword")]
        public string CurrentPassword { get; set; }
    }  
}
