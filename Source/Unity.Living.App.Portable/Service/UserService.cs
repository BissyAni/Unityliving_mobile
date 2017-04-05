using System;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Service
{
    public class UserService
    {
        public async Task<UserDetailViewModel> GetUserDetails(int id)
        {
            var service = DependencyService.Get<IUserOverview>();
            var result = await service.GetUserHouseDetails(id);

            var userDetailViewModel = new UserDetailViewModel()
            {
                HouseID = result.House.Id,
                ID = result.House.DoorNumber,
                Address = result.House.TenantAddress,
                Email = result.House.TenantEmail,
                Mobile = result.House.TenantMobile,
                Name = result.House.TenantName,
                Phone1 = result.House.TenantPhone1,
                Phone2 = result.House.TenantPhone2,
                Rented = result.House.Rented ? "ok.png" : "wrong.png",
                tenant_end_date = result.House.TenantEndDate,
                tenant_start_date = result.House.TenantStartDate,
                email_notification = result.House.EmailNotification,
                notify_tenant = result.House.NotifyTenant,
                IsEmailNotification = result.House.EmailNotification ? "ok.png" : "wrong.png",
                IsSMSNotification = result.House.SMSNotification ? "ok.png" : "wrong.png",
                IsNotifyTenant = result.House.NotifyTenant ? "ok.png" : "wrong.png",
                IsAutoSettleDuesfromAdvance = result.House.SettleFromAdvance ? "ok.png" : "wrong.png",
                AreaInSqft = result.House.Area,
                NumberofAdults = result.House.NumberOfAdults,
                NumberofChildren = result.House.NumberOfChildren,
                IntercomNumber = result.House.Intercom,
                LocalBodyHouseNumber = result.House.LocalBodyHouseNumber,
                ElectricityConsumerNumber = result.House.ElectricityConsumerNumber,
                SaleDeedNumber = result.House.SaleDeedNumber,
                VehicleNumber = result.House.VehicleNumber,
                VehicleMake = result.House.VehicleMake,
                Comments = result.House.Comments,
                resident = result.House.Resident,
                owner_address = result.House.OwnerAddress,
                owner_email = result.House.OwnerEmail,
                owner_email2 = result.House.OwnerEmail2,
                owner_mobile = result.House.OwnerMobile,
                owner_name = result.House.OwnerName,
                owner_phone1 = result.House.OwnerPhone1,
                owner_phone2 = result.House.OwnerPhone2,
                owner_end_date = result.House.OwnerEndDate,
                owner_start_date = result.House.OwnerStartDate,
            };
            return userDetailViewModel;
        }

        public async Task<TenantDetailsViewModel> GetTenentEditDetails(int id)
        {
            var service = DependencyService.Get<IUserOverview>();
            var result = await service.GetTenentEditDetails(id);
            var tdvm = new TenantDetailsViewModel
            {
                ID = Convert.ToString(result.House.Id),
                Rented = result.House.Rented,
                Name = result.House.TenantName,
                Address = result.House.TenantAddress,
                Phone1 = result.House.TenantPhone1,
                Phone2 = result.House.TenantPhone2,
                Mobile = result.House.TenantMobile,
                Email = result.House.TenantEmail,
                PeriodFrom = Convert.ToDateTime(result.House.TenantStartDate),
                PeriodTo = Convert.ToDateTime(result.House.TenantEndDate),
            };
            return tdvm;
        }

        public async Task<HouseDetailsViewModel> GetHouseEditDetails(int id)
        {
            var service = DependencyService.Get<IUserOverview>();
            var result = await service.GetHouseEditDetails(id);
            var hdvm = new HouseDetailsViewModel
            {
                ID = Convert.ToString(result.House.Id),
                IsEmailNotification = result.House.EmailNotification,
                IsSMSNotification = result.House.SMSNotification,
                IsNotifyTenant = result.House.NotifyTenant,
                IsAutoSettleDuesfromAdvance = result.House.SettleFromAdvance,
                AreaInSqft = result.House.Area,
                NumberofAdults =Convert.ToString(result.House.NumberOfAdults),
                NumberofChildren =Convert.ToString(result.House.NumberOfChildren),
                IntercomNumber =Convert.ToString(result.House.Intercom),
                LocalBodyHouseNumber = result.House.LocalBodyHouseNumber,
                ElectricityConsumerNumber = result.House.ElectricityConsumerNumber,
                SaleDeedNumber = result.House.SaleDeedNumber,
                VehicleNumber = result.House.VehicleNumber,
                VehicleMake = result.House.VehicleMake,
                Comments = result.House.Comments,
                Resident = result.House.Resident
            };
            return hdvm;
        }

        public async Task<OwnerDetailsViewModel> GetOwnerEditDetails(int id)
        {
            var service = DependencyService.Get<IUserOverview>();
            var result = await service.GetOwnerEditDetails(id);
            var odvm = new OwnerDetailsViewModel
            {
                ID = Convert.ToString(result.House.Id),
                Name = result.House.OwnerName,
                Address = result.House.OwnerAddress,
                Phone1 = result.House.OwnerPhone1,
                Phone2 = result.House.OwnerPhone2,
                Email1 = result.House.OwnerEmail,
                Email2 = result.House.OwnerEmail2,
                Mobile = result.House.OwnerMobile,
                PeriodFrom = Convert.ToDateTime(result.House.OwnerStartDate),
                PeriodTo = Convert.ToDateTime(result.House.OwnerEndDate)
            };
            return odvm;
        }
    }
}
