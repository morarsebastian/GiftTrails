using GiftTrails.Gifts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Web.Models.Gifts
{
    public class IndexViewModel
    {
        public IReadOnlyList<GiftListDto> Gifts { get; }

        public IndexViewModel(IReadOnlyList<GiftListDto> gifts)
        {
            Gifts = gifts;
        }
    }
}
