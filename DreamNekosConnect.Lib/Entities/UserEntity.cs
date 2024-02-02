using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamNekosConnect.Lib.Entities
{
    public class UserEntity : BasicEntity
    {
        public required long TgId { get; set; }
        public string Name { get; set; }
        public string? About {  get; set; }
        public List<InterestEntity> Interest { get; set; } = new List<InterestEntity>();
        public List<UserInterestEntity> UserInterest { get; set; }
        public List<LinkEntity> Links { get; set; } = new List<LinkEntity>();

    }
}