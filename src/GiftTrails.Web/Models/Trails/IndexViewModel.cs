using GiftTrails.Trails.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftTrails.Web.Models.Trails
{
    public class IndexViewModel
    {
        public IReadOnlyList<TrailListDto> Trails { get; }

        public IndexViewModel(IReadOnlyList<TrailListDto> trails)
        {
            Trails = trails;
        }
    }
}
