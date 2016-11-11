using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using GiftTrails.Gifts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Trails
{
    [Table("Trails")]
    public class Trail : Entity, IHasCreationTime
    {
        public const int MaxLocationLength = 256;

        [Required]
        [MaxLength(MaxLocationLength)]
        public string CityName { get; set; }

        [Required]
        [MaxLength(MaxLocationLength)]
        public string CountryName { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public string GooglePlaceId { get; set; }

        public DateTime CreationTime { get; set; }

        [ForeignKey(nameof(CreatorUserId))]
        public GiftTrails.Users.User CreatorUser { get; set; }
        public long CreatorUserId { get; set; }

        [ForeignKey(nameof(GiftId))]
        public Gift Gift { get; set; }
        public int GiftId { get; set; }

        public Trail(int giftId)
        {
            CreationTime = Clock.Now;
            GiftId = giftId;
        }

        public Trail()
        {
            CreationTime = Clock.Now;
        }
    }
}
