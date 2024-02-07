using DreamNekos.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamNekos.API.Response
{
    public class StatisticResponse
    {
        [Required]
        public required int UserCount { get; set; }
        public List<InterestPopularityByTypeResponse> InterestPopularityByType { get; set; }
    }
}
