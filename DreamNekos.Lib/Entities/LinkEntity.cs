using DreamNekos.Core.Entities;

namespace DreamNekosConnect.Lib.Entities
{
    public class LinkEntity : BasicEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}