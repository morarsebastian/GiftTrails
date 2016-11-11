using System.Threading.Tasks;
using Abp.Application.Services;
using GiftTrails.Roles.Dto;

namespace GiftTrails.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
