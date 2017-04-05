using System;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.Threading.Tasks;
using System.Threading;
using Android.Content.Res;
using Java.Lang;
using Newtonsoft.Json;
using Unity.Living.App.Portable.Helpers;
using Xamarin.Forms;

namespace Unity.Living.AppAndroid
{
    public class ServiceBaseAndroid
    {
        string GetBaseUrl = UrlHelper.BaseUrl;

        protected async Task<string> FetchAsync(string url)
        {
            string token = GetAuthKey();
            var requestUrl = GetBaseUrl + url;
            Uri myUri = new Uri(requestUrl, UriKind.Absolute);
            var client = new RestClient(myUri);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", string.Format(token));
            IRestResponse response = client.Execute(request);
            if (response.Content == "{\"detail\":\"Invalid token\"}")
            {
                App.Portable.App.TokenExpired = true;
            }
            //var client1 = new HttpClient();
            //client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("cache-control", "no-cache");
            //client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", App.Portable.App.AuthKey.Token);
            //client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var response1 = await client1.GetAsync(myUri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            //if (response1.IsSuccessStatusCode)
            //{
            //    var content = response1.Content.ReadAsStringAsync().Result;
            //}
            return response.Content;
        }

        protected async Task<string> PostAsyncWithoutAuth<T>(string url, T payload)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var client = new RestClient(GetBaseUrl + url);
            var request = new RestRequest(url);
            var output = JsonConvert.SerializeObject(payload);
            request.AddParameter("text/json", output, ParameterType.RequestBody);
            var result = await client.ExecutePostTaskAsync(request, cancellationTokenSource.Token);
            return result.Content;
        }

        protected async Task<string> PostAsync<T>(string url, T payload)
        {
            string token = GetAuthKey();
            var cancellationTokenSource = new CancellationTokenSource();
            var client = new RestClient(GetBaseUrl + url);
            var request = new RestRequest(url);
            var output = JsonConvert.SerializeObject(payload);
            request.AddHeader("Authorization", string.Format(token));
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var result = await client.ExecutePostTaskAsync(request, cancellationTokenSource.Token);
            return result.Content;
        }

        protected async Task<string> PostAsyncCustom<T>(string url, T payload)
        {
            var jsontemp = JsonConvert.SerializeObject(payload);
            var client = new RestClient(GetBaseUrl + url);
            var request = new RestRequest(Method.POST);
            string token = GetAuthKey();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", token);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", jsontemp, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        protected async Task<string> PutAsync<T>(string url, T payload)
        {
            var client = new RestClient(GetBaseUrl + url);
            var request = new RestRequest(Method.PUT);
            var json = JsonConvert.SerializeObject(payload);
            string token = GetAuthKey();
            string ss = token;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", token);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content; ;
        }

        protected async Task<bool> DeleteAsync(string url)
        {
            string token = GetAuthKey();
            var cancellationTokenSource = new CancellationTokenSource();
            var client = new RestClient(GetBaseUrl + url);
            var request = new RestRequest(url, Method.DELETE);
            request.AddHeader("Authorization", string.Format(token));
            await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            return true;
        }

        public static string GetAuthKey()
        {
          //  var token = "Token " + "b654e11620c0a849d9abd115ce584405f61a87fd";
               var token = "Token " + App.Portable.App.AuthKey.Token;
            return token;
        }

        public static int GetUserId()
        {
            var userId = App.Portable.App.AuthKey.UserDetails.Id;
            return userId;
        }

    }
}