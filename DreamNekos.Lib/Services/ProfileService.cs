using DreamNekos.API.Helpers;
using DreamNekos.Common.Enums;
using DreamNekos.Core;
using DreamNekos.Core.Entities;
using DreamNekos.Core.Entities.Activity;
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
        public List<UserEntity> GetProfiles()
        {
            var users = _dbContext.Users
                .Include(x => x.Links)
                .Include(x => x.UserInterest).ThenInclude(x => x.Interest).ThenInclude(x => x.InterestType).ToList();
            return users;
        }
        public UserEntity GetProfileById(Guid id) {
            var user = _dbContext.Users
                .Include(x => x.Links)
                .Include(x => x.UserInterest).ThenInclude(x => x.Interest).ThenInclude(x => x.InterestType)
                .FirstOrDefault(u => u.Id == id);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            return user;
        }
        public UserEntity GetProfileByTgId(long tgId) {
            var user = _dbContext.Users.FirstOrDefault(u => u.TgId == tgId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            return user;
        }
        public UserEntity UpdateProfile(Guid userId, string? name, string? about)
        {
            var user = _dbContext.Users
                .FirstOrDefault(x => x.Id ==  userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            if (name != null) user.Name = name;
            if(about != null) user.About = about;
            _dbContext.SaveChanges();
            return user;
        }
        public UserActivityEntity AddInterest(Guid userId, Guid interestId, FamiliarizationLevel? familiarizationLevel) {
            ActivityEntity interest = _dbContext.Activities.FirstOrDefault(x => x.Id == interestId);
            if (interest == null) throw new ElementNotFoundException("A interest with such an ID does not exist.");
            UserEntity user = _dbContext.Users
                .First(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            var newUserInterest = new UserActivityEntity { User = user, Actvity = interest, FamiliarizationLevel = familiarizationLevel };
            _dbContext.UserInterest.Add(newUserInterest);
            _dbContext.SaveChanges();
            return newUserInterest;
        }
        public List<UserActivityEntity> GetAllInterest(Guid userId)
        {
            UserEntity user = _dbContext.Users
                .Include(x => x.UserInterest)
                .ThenInclude(x => x.Interest)
                .ThenInclude(x => x.InterestType)
                .First(x => x.Id == userId);
            var response = user.UserInterest.ToList();
            return response;
        }
        public void RemoveInterest(Guid userId, Guid userInterestId)
        {
            UserEntity user = _dbContext.Users
                .Include(x => x.UserInterest)
                .First(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            var interestUserItem = user.UserInterest.FirstOrDefault(x => x.Id == userInterestId);
            if (interestUserItem == null) throw new ElementNotFoundException("A interest with such an ID does not exist.");
            user.UserInterest.Remove(interestUserItem);
            _dbContext.SaveChanges();
        }
        public LinkEntity CreateLink(Guid userId, string name, string url)
        {
            UserEntity user = _dbContext.Users
                .Include(x => x.Links)
                .First(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            LinkEntity link = new LinkEntity { Name = name, Url = url };
            user.Links.Add(link);
            _dbContext.SaveChanges();
            return link;
        }
        public void DeleteLink(Guid userId, Guid linkId)
        {
            UserEntity user = _dbContext.Users
                .Include(x => x.Links)
                .First(x => x.Id == userId);
            if (user == null) throw new ElementNotFoundException("A user with such an ID does not exist.");
            var link = user.Links.FirstOrDefault(x => x.Id == linkId);
            if (link == null) throw new ElementNotFoundException("A link with such an ID does not exist.");
            user.Links.Remove(link);
            _dbContext.SaveChanges();
        }
    }
}
