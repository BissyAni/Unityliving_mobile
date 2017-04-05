using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Models.OverView;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Service
{
    public class ServiceRequestService
    {
        public async Task<List<ServiceModel>> GetAllServiceRequest()
        {
            var service = DependencyService.Get<IServiceRequest>();
            var result = await service.GetServiceRequest();
            var serviceRequests = result.Sr.Select(r => new ServiceModel
            {
                ID = r.Id,
                Subject = r.Subject,
                HouseID = r.House,
                HouseName =Convert.ToString(r.House),
                CategoryID = r.Category,
                PreferredDate = Convert.ToDateTime(r.PreferredDate),
                Status=r.Closed? "Closed" : "Open",
                CreatedDate= Convert.ToDateTime(r.CreatedDate),
                CreatedBy = r.CreatedUser.ToString(),
                LastUpdate=Convert.ToDateTime(r.UpdatedDate)

            }).OrderByDescending(i => i.Status).ThenByDescending(i=>i.LastUpdate).ToList();
            return serviceRequests;          
        }
        
        public async Task<bool> ServiceRequestCreate(ServiceRequest ser)
        {
            var service = DependencyService.Get<IServiceRequest>();
            var result = await service.CreateServiceRequest(ser);
            return result;
        }

        public async Task<ServiceRequestSpecificModel> GetServiceRequestById(int id)
        {
            var service = DependencyService.Get<IServiceRequest>();
            var result = await service.GetServiceRequestById(id);
            return result;
        }        
    }
}
