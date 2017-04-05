using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public  class AddCommentToServiceRequestModel : ModelBase
    {
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
    }
}
