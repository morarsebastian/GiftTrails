using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Trails.Dtos
{
    [AutoMapFrom(typeof(Trail))]
    public class TrailListDto : EntityDto, IHasCreationTime
    {
        public string CityName { get; set; }

        public string CountryName { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public DateTime CreationTime { get; set; }

        public long CreatorUserId { get; set; }
        public string CreatorUserName { get; set; }

        public int GiftId { get; set; }
        public string GiftTitle { get; set; }

    }
}
