using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GiftTrails.MultiTenancy.Dto;

namespace GiftTrails.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
