using DreamNekos.API.Helpers;
using DreamNekos.Core;
using DreamNekos.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamNekosConnect.Lib.Services
{
    public class InterestTypeService
    {
        private ApplicationDbContext _dbContext { get; set; }
        public InterestTypeService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public ActivityTypeEntity CreateInterestType(string name)
        {
            var newInterestType = new ActivityTypeEntity { Name = name };
            _dbContext.Add(newInterestType);
            _dbContext.SaveChanges();
            return newInterestType;
        }
        public ActivityTypeEntity GetInterestType(Guid interestId)
        {
            var interestType = _dbContext.InterestType
                .Include(x => x.Interests)
                .FirstOrDefault(x => x.Id == interestId);
            if (interestType == null) throw new ElementNotFoundException("A interest type with such an ID does not exist.");
            return interestType;
        }
        public List<ActivityTypeEntity> GetAllInterestType()
        {
            var interestType = _dbContext.InterestType;
            return interestType.ToList();
        }
        public ActivityTypeEntity UpdateInterestType(Guid interestId, string? name)
        {
            var interestType = _dbContext.InterestType.FirstOrDefault(x => x.Id == interestId);
            if (interestType == null) throw new ElementNotFoundException("A interest type with such an ID does not exist.");
            if (name != null) interestType.Name = name;
            _dbContext.SaveChanges();
            return interestType;
        }
        public void DeleteInterestType(Guid interestTypeId)
        {
            var interestType = _dbContext.InterestType.FirstOrDefault(x => x.Id == interestTypeId);
            if (interestType == null) throw new ElementNotFoundException("A interest type with such an ID does not exist.");

            var interests = _dbContext.Activities.Where(x => x.InterestTypeId == interestTypeId).ToList();
            foreach(var interest in interests)
            {
                interest.InterestType = null;
                interest.InterestTypeId = null;
            }

            _dbContext.Remove(interestType);
            _dbContext.SaveChanges();
        }
    }
}
