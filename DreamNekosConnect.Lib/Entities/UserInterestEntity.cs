using DreamNekosConnect.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamNekosConnect.Lib.Entities
{
    public class UserInterestEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required UserEntity User { get; set; }
        public Guid InterestId { get; set; }
        public required InterestEntity Interest { get; set; }
        public FamiliarizationLevel? FamiliarizationLevel { get; set; }
    }
}
