using Newtonsoft.Json;
using System.Collections.Generic;

namespace Unity.Living.App.Portable.Models
{
    public class ServiceRequestModel
    {
        public List<ServiceRequestData> Sr { get; set; }
    }

    public  class ServiceRequestData
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
        [JsonProperty(PropertyName = "allotted_time")]
        public object AllottedTime { get; set; }
        [JsonProperty(PropertyName = "delivery_date")]
        public object DeliveryDate { get; set; }
        [JsonProperty(PropertyName = "updated_user")]
        public object UpdatedUser { get; set; }
        [JsonProperty(PropertyName = "category")]
        public int Category { get; set; }
        [JsonProperty(PropertyName = "preferred_timings")]
        public int? PreferredTimings { get; set; }
        [JsonProperty(PropertyName = "house")]
        public int House { get; set; }
        [JsonProperty(PropertyName = "created_user")]
        public int CreatedUser { get; set; }
        [JsonProperty(PropertyName = "staff")]
        public object Staff { get; set; }
        [JsonProperty(PropertyName = "keypersonnel")]
        public object KeyPersonnel { get; set; }
        [JsonProperty(PropertyName = "site")]
        public int Site { get; set; }
    }
 }
