using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using GiftTrails.Gifts.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Gifts
{
    public class GiftAppService : GiftTrailsAppServiceBase, IGiftAppService
    {
        private readonly IRepository<Gift> _giftRepository;

        public GiftAppService(IRepository<Gift> giftRepository)
        {
            _giftRepository = giftRepository;
        }

        public async Task<ListResultDto<GiftListDto>> GetAll()
        {
            var gifts = await _giftRepository
                .GetAll()
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<GiftListDto>(ObjectMapper.Map<List<GiftListDto>>(gifts));
        }
    }
}
