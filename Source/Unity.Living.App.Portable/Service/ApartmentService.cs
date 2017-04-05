using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models.Apartment;

namespace Unity.Living.App.Portable.Service
{
    public class ApartmentService : IApartmentService
    {
        public async Task<List<ApartmentModel>> GetApartments()
        {
            HttpClient client = new HttpClient();
            var address = new Uri("http://mobile.unityliving.com/sites-autocomplete/");
            var response = await client.GetAsync(address,HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            var content = response.Content.ReadAsStringAsync().Result;
            var dd = JsonConvert.DeserializeObject<List<ApartmentModel>>(content);
            return dd;
        }
    }
}
