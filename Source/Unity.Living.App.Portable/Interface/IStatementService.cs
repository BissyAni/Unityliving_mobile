using System.Threading.Tasks;
using Unity.Living.App.Portable.Models;

namespace Unity.Living.App.Portable.Interface
{
    public  interface IStatementService
    {
        Task<StatementModel> GetStatement(int houseId);
        Task<DuesStatementModel> GetDuesStatement(int houseId);
        Task<AdvanceStatementModel> GetAdvanceStatement(int houseId);
    }
}
