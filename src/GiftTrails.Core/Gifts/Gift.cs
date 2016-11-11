using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using GiftTrails.Trails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Gifts
{
    [Table("Gifts")]
    public class Gift : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 65536; //64KB

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        [ForeignKey(nameof(CreatorUserId))]
        public GiftTrails.Users.User CreatorUser { get; set; }
        public long CreatorUserId { get; set; }

        public virtual IEnumerable<Trail> Trails { get; set; }

        public Gift()
        {
            CreationTime = Clock.Now;
        }

        public Gift(string title, string description = null)
            : this()
        {
            Title = title;
            Description = description;
        }
    }
}
