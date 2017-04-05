using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.HouseAndCategory
{
    public class ServiceRequest
    {
        [JsonProperty(PropertyName = "preferred_date")]
        public object PreferredDate { get; set; }
        [JsonProperty(PropertyName = "closed")]
        public bool Closed { get; set; }
        [JsonProperty(PropertyName = "closed_date")]
        public object ClosedDate { get; set; }
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
        [JsonProperty(PropertyName = "allotted_time")]
        public string AllottedTime { get; set; }
        [JsonProperty(PropertyName = "delivery_date")]
        public object DeliveryDate { get; set; }
        [JsonProperty(PropertyName = "updated_user")]
        public object UpdatedUser { get; set; }
        [JsonProperty(PropertyName = "category")]
        public object Category { get; set; }
        [JsonProperty(PropertyName = "preferred_timings")]
        public object PreferredTimings { get; set; }
        [JsonProperty(PropertyName = "house")]
        public object House { get; set; }
        [JsonProperty(PropertyName = "created_user")]
        public object CreatedUser { get; set; }
        [JsonProperty(PropertyName = "staff")]
        public object Staff { get; set; }
        [JsonProperty(PropertyName = "keypersonnel")]
        public object KeyPersonnel { get; set; }
        [JsonProperty(PropertyName = "site")]
        public object Site { get; set; }
    }
}
