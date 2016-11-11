using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Trails.Dtos
{
    [AutoMapTo(typeof(Trail))]
    public class CreateTrailInput
    {
        [Required]
        [MaxLength(Trail.MaxLocationLength)]
        public string CityName { get; set; }

        [Required]
        [MaxLength(Trail.MaxLocationLength)]
        public string CountryName { get; set; }

        [Required]
        public decimal Latitude { get; set; } = 0;

        [Required]
        public decimal Longitude { get; set; } = 0;

        public long CreatorUserId { get; set; }

        public int GiftId { get; set; }
    }
}
