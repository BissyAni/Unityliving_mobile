using System.Threading.Tasks;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Models.OverView;

namespace Unity.Living.App.Portable.Interface
{
    public interface IServiceRequest
    {
        Task<HouseAndCategoriesModel> GetAllDropDown();
        Task<bool> CreateServiceRequest(ServiceRequest stream);
        Task<ServiceRequestModel> GetServiceRequest();
        Task<ServiceRequestSpecificModel> GetServiceRequestById(int Id);
        Task<bool> AddCommentsEdit(int id, AddCommentToServiceRequestModel addCm);
    }
}
