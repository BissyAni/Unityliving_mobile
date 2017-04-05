using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.DuesModels
{
    public class PaymentIntegratedSite
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "sites_with_pay")]
        public List<int> SitesWithPay { get; set; }
    }
}
