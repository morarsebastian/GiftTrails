using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GiftTrails.Gifts.Dtos;

namespace GiftTrails.Gifts
{
    public interface IGiftAppService : IApplicationService
    {
        Task<ListResultDto<GiftListDto>> GetAll();
    }
}
