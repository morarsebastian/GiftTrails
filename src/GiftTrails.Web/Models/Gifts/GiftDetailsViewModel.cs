using GiftTrails.Gifts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Web.Models.Gifts
{
    public class GiftDetailsViewModel
    {
        public GiftListDto Gift { get; }

        public GiftDetailsViewModel(GiftListDto gift)
        {
            Gift = gift;
        }
    }
}
