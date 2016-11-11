using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using GiftTrails.Gifts.Dtos;
using GiftTrails.Trails;
using GiftTrails.Trails.Dtos;
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
        private readonly IRepository<Trail> _trailRepository;

        public GiftAppService(IRepository<Gift> giftRepository, IRepository<Trail> trailRepository)
        {
            _giftRepository = giftRepository;
            _trailRepository = trailRepository;
        }

        public async Task<ListResultDto<GiftListDto>> GetAll()
        {
            var gifts = await _giftRepository
                .GetAll()
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            var output = ObjectMapper.Map<List<GiftListDto>>(gifts);

            foreach (var gift in output)
            {
                var giftTrails = await _trailRepository
                    .GetAll()
                    .Where(t => t.GiftId == gift.Id)
                    .OrderByDescending(t => t.CreationTime)
                    .ToListAsync();

                gift.Trails.AddRange(ObjectMapper.Map<List<TrailListDto>>(giftTrails));
            }

            return new ListResultDto<GiftListDto>(output);
        }
    }
}
