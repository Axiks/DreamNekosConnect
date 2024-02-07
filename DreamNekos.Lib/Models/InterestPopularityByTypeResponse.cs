using DreamNekosConnect.Lib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamNekos.Core.Models
{
    public struct InterestPopularityByTypeResponse
    {
        [Required]
        public required Guid TypeId { get; set; }
        [Required]
        public required string TypeName { get; set; }
        public List<InterestPopularityResponse> InterestPopularityList { get; set; }
    }

    public struct InterestPopularityResponse
    {
        [Required]
        public required Guid InterestId { get; set; }
        [Required]
        public required string InterestName { get; set; }
        [Required]
        public required int Score { get; set; }
    }
}
