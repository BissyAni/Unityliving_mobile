using System.Collections.Generic;
using Unity.Living.App.Portable.Interface;
using Unity.Living.AppAndroid;
using Xamarin.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Living.App.Portable.Models;
using Java.Lang;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Models.OverView;

[assembly: Dependency(typeof(ServiceRequestAndroid))]
namespace Unity.Living.AppAndroid.Service
{ }
public class ServiceRequestAndroid : ServiceBaseAndroid, IServiceRequest
{
    public async Task<HouseAndCategoriesModel> GetAllDropDown()
    {
        var json = await FetchAsync(UrlHelper.ServiceRequestCreate);
        return JsonConvert.DeserializeObject<HouseAndCategoriesModel>(json);
    }

    public async Task<bool> CreateServiceRequest(ServiceRequest service_request)
    {
        var json = await PostAsync<ServiceRequest>(UrlHelper.ServiceRequestCreate, service_request);
        if (json == "{\"success\":true}")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<List<ServiceRequest>> ServiceRequestSearchandList()
    {
        var json = await FetchAsync(UrlHelper.ServiceRequestCreate);
        return JsonConvert.DeserializeObject<List<ServiceRequest>>(json);
    }

    public async Task<ServiceRequestModel> GetServiceRequest()
    {
        var url = String.Format(UrlHelper.ServiceRequest);
        var json = await FetchAsync(url);
        var result = JsonConvert.DeserializeObject<ServiceRequestModel>(json);
        return result;
    }
        
    public async Task<ServiceRequestSpecificModel> GetServiceRequestById(int ServiceId)
    {
        var url = String.Format(UrlHelper.ServiceRequestView + ServiceId);
        var json = await FetchAsync(url);
        var result = JsonConvert.DeserializeObject<ServiceRequestSpecificModel>(json);
        return result;
    }

    public async Task<bool> AddCommentsEdit(int id, AddCommentToServiceRequestModel addCm)
    {
        var url = String.Format(UrlHelper.ServiceRequestView + id);
        var result = await PutAsync<AddCommentToServiceRequestModel>(url, addCm);
        if (result == "{\"success\":true}")
            return true;
        else
            return false;
    }

}
