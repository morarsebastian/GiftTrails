using GiftTrails.Trails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Web.Models.Trails
{
    public class CreateTrailViewModel
    {
        [Required]
        [MaxLength(Trail.MaxLocationLength)]
        public string CityName { get; set; }

        [Required]
        [MaxLength(Trail.MaxLocationLength)]
        public string CountryName { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public long CreatorUserId { get; set; }

        public int GiftId { get; set; }

        public CreateTrailViewModel(long creatorUserId, int giftId)
        {
            CreatorUserId = creatorUserId;
            GiftId = giftId;
        }
    }
}
