using System.Threading.Tasks;
using Abp.Application.Services;
using GiftTrails.Sessions.Dto;

namespace GiftTrails.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
