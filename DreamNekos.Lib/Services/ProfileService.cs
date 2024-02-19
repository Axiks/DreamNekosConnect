using DreamNekos.API.Helpers;
using DreamNekos.Common.Enums;
using DreamNekos.Core;
using DreamNekos.Core.Entities;
using DreamNekosConnect.Lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamNekosConnect.Lib.Services
{
    public class ProfileService
    {
        private ApplicationDbContext _dbContext { get; set; }
        public ProfileService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public UserEntity CreateProfile(long tgId, string name, string? about)
        {
            var newUser = new UserEntity{ TgId = tgId, Name = name, About = about };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }

        public async Task<List<UserEntity>> GetProfiles()
        {
            var users = await _dbContext.Users
                .Include(x => x.Links)
                .Include(x => x.ActivitiesPrefix).ThenInclude(x => x.Actvity)
                .Include(x => x.SkillsPrefix).ThenInclude(x => x.Skill)
                //.Include(x => x.Activities)
                //.Include(x => x.Skills)
                .ToListAsync();
            return users;
        }

        public async Task<UserEntity> GetProfileById(Guid id) {
            var user = await _dbContext.Users
                .Include(x => x.Links)
                .Include(x => x.ActivitiesPrefix).ThenInclude(x => x.Actvity)
                .Include(x => x.SkillsPrefix).ThenInclude(x => x.Skill)
                //.Include(x => x.Activities)
                //.Include(x => x.Skills)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            return user;
        }

        public async Task<UserEntity> GetProfileByTgId(long tgId) {
            var user = await _dbContext.Users
                .Include(x => x.Links)
                .Include(x => x.ActivitiesPrefix).ThenInclude(x => x.Actvity)
                .Include(x => x.SkillsPrefix).ThenInclude(x => x.Skill)
                //.Include(x => x.Activities)
                //.Include (x => x.Skills)
                .FirstOrDefaultAsync(u => u.TgId == tgId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            return user;
        }

        public async Task<UserEntity> UpdateProfile(Guid userId, string? name, string? about)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id ==  userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            if (name != null) user.Name = name;
            if (about != null) user.About = about;
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<LinkEntity> CreateLink(Guid userId, string name, string url)
        {
            var user = await _dbContext.Users
                .Include(x => x.Links)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            LinkEntity link = new LinkEntity { Name = name, Url = url };
            user.Links.Add(link);
            await _dbContext.SaveChangesAsync();
            return link;
        }

        public async Task DeleteLink(Guid userId, Guid linkId)
        {
            var user = await _dbContext.Users
                .Include(x => x.Links)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            var link = user.Links.FirstOrDefault(x => x.Id == linkId);
            if (link == null) throw new ElementNotFoundException("A link with such an ID does not exist.");
            user.Links.Remove(link);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserActivityEntity> AddActivity(Guid userId, Guid activityId, EngagmentLevel engagmentLevel = EngagmentLevel.Hobby)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");

            var activity = await _dbContext.Activity
                .FirstOrDefaultAsync(x => x.Id == activityId);
            if (activity == null) throw new ElementNotFoundException("A activity with such an ID does not exist.");

            var newActivityConnection = new UserActivityEntity() {
                Actvity = activity,
                User = user,
                EngagmentLevel = engagmentLevel
            };

            await _dbContext.AddAsync(newActivityConnection);
            return newActivityConnection;
        }

        public async Task<UserActivityEntity> UpdateActivity(Guid userId, Guid activityId, EngagmentLevel? engagmentLevel)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");

            var activity = await _dbContext.Activity
                .FirstOrDefaultAsync(x => x.Id == activityId);
            if (activity == null) throw new ElementNotFoundException("A activity with such an ID does not exist.");

            var entity = await _dbContext.UserActivity.FirstOrDefaultAsync(x => x.User.Id == userId && x.Actvity.Id == activityId);
            if (entity == null) throw new ElementNotFoundException("The activity and the user with such an ID does not exist.");//

            if (engagmentLevel != null) entity.EngagmentLevel = (EngagmentLevel)engagmentLevel;

            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task RemoveActivity(Guid userId, Guid activityId)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");

            var activity = await _dbContext.Activity
                .FirstOrDefaultAsync(x => x.Id == activityId);
            if (activity == null) throw new ElementNotFoundException("A activity with such an ID does not exist.");

            var result = await _dbContext.UserActivity.FirstOrDefaultAsync(x => x.User.Id == userId && x.Actvity.Id == activityId);
            if(result == null) throw new ElementNotFoundException("The activity and the user with such an ID does not exist.");//

            _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserSkillEntity> AddSkill(Guid userId, Guid skillId, FamiliarizationLevel familiarizationLevel = FamiliarizationLevel.Interest)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");

            var skill = await _dbContext.Skill
                .FirstOrDefaultAsync(x => x.Id == skillId);
            if (skill == null) throw new ElementNotFoundException("A skill with such an ID does not exist.");

            var newSkillConnection = new UserSkillEntity()
            {
                Skill = skill,
                User = user,
                FamiliarizationLevel = familiarizationLevel
            };

            await _dbContext.AddAsync(newSkillConnection);
            await _dbContext.SaveChangesAsync();

            return newSkillConnection;
        }

        public async Task<UserSkillEntity> UpdateSkill(Guid userId, Guid skillId, FamiliarizationLevel? familiarizationLevel)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");

            var skill = await _dbContext.Skill
                .FirstOrDefaultAsync(x => x.Id == skillId);
            if (skill == null) throw new ElementNotFoundException("A skill with such an ID does not exist.");

            var entity = await _dbContext.UserSkill.FirstOrDefaultAsync(x => x.User.Id == userId && x.Skill.Id == skillId);
            if (entity == null) throw new ElementNotFoundException("The skill and the user with such an ID does not exist.");//

            if (familiarizationLevel != null) entity.FamiliarizationLevel = (FamiliarizationLevel)familiarizationLevel;

            await _dbContext.SaveChangesAsync();
            return entity;
        }


        public async Task RemoveSkill(Guid userId, Guid skillId)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");

            var skill = await _dbContext.Skill
                .FirstOrDefaultAsync(x => x.Id == skillId);
            if (skill == null) throw new ElementNotFoundException("A skill with such an ID does not exist.");

            var result = await _dbContext.UserSkill.FirstOrDefaultAsync(x => x.User.Id == userId && x.Skill.Id == skillId);
            if (result == null) throw new ElementNotFoundException("The skill and the user with such an ID does not exist.");//

            _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
