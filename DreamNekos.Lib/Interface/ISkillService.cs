using DreamNekos.Core.Entities;
using DreamNekos.Core.Models.DTO.Skill;

namespace DreamNekos.Core.Interface
{
    public interface ISkillService
    {
        public Task<SkillEntity> GetSkillById(Guid SkillId);
        public Task<List<SkillEntity>> GetAllSkill();

        public Task<SkillEntity> CreateSkill(CreateSkillDTO create);
        public Task<SkillEntity> UpdateSkill(Guid SkillId, UpdateSkillDTO update);

        public Task DeleteSkill(Guid SkillId);
    }
}
