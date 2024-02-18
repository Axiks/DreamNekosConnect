using DreamNekos.Core.Entities;
using DreamNekos.Core.Models.DTO;

namespace DreamNekos.Core.Interface
{
    public interface ISkillService
    {
        public SkillEntity GetSkillById(Guid SkillId);
        public List<SkillEntity> GetAllSkill();

        public SkillEntity CreateSkill(SkillDTO skillDTO);
        public SkillEntity UpdateSkill(Guid SkillId, SkillDTO skillDTO);

        public void DeleteSkill(Guid SkillId);
    }
}
