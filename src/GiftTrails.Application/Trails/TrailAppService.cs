using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using GiftTrails.Trails.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Trails
{
    public class TrailAppService : GiftTrailsAppServiceBase, ITrailAppService
    {
        private readonly IRepository<Trail> _trailRepository;

        public TrailAppService(IRepository<Trail> trailRepository)
        {
            _trailRepository = trailRepository;
        }

        public async Task<ListResultDto<TrailListDto>> GetAll(GetAllTrailsInput input)
        {
            var trails = await _trailRepository
                .GetAll()
                .Where(t => t.GiftId == input.GiftId)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<TrailListDto>(ObjectMapper.Map<List<TrailListDto>>(trails));
        }
    }
}
