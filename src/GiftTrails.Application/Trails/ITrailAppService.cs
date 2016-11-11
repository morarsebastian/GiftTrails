using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GiftTrails.Trails.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Trails
{
    public interface ITrailAppService : IApplicationService
    {
        Task<ListResultDto<TrailListDto>> GetAll(GetAllTrailsInput input);
    }
}
