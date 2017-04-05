using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public class SignInModel
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "apartment_name")]
        public string ApartmentName { get; set; }
    }
}
