using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.ServiceRequestSpecific
{
    public class SRData
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "created_date")]
        public string CreatedDate { get; set; }
        [JsonProperty(PropertyName = "updated_date")]
        public string UpdatedDate { get; set; }
        [JsonProperty(PropertyName = "preferred_date")]
        public string PreferredDate { get; set; }
        [JsonProperty(PropertyName = "closed")]
        public bool Closed { get; set; }
        [JsonProperty(PropertyName = "closed_date")]
        public string ClosedDate { get; set; }
        [JsonProperty(PropertyName = "was_closed")]
        public bool WasClosed { get; set; }
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
        [JsonProperty(PropertyName = "next_action")]
        public string NextAction { get; set; }
        [JsonProperty(PropertyName = "escalated_group")]
        public string EscalatedGroup { get; set; }
        [JsonProperty(PropertyName = "feedback_comment")]
        public string FeedbackComment { get; set; }
        [JsonProperty(PropertyName = "updated_user")]
        public string UpdatedUser { get; set; }
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        [JsonProperty(PropertyName = "preferred_timings")]
        public string PreferredTimings { get; set; }
        [JsonProperty(PropertyName = "house")]
        public string House { get; set; }
        [JsonProperty(PropertyName = "created_user")]
        public string CreatedUser { get; set; }
        [JsonProperty(PropertyName = "site")]
        public string Site { get; set; }
    }
}
