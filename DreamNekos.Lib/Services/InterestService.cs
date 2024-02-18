using DreamNekos.API.Helpers;
using DreamNekos.Core;
using DreamNekos.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamNekosConnect.Lib.Services
{
    public class InterestService
    {
        private ApplicationDbContext _dbContext { get; set; }
        public InterestService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public ActivityEntity CreateInterest(string name, Guid? interestTypeId)
        {
            var interestType = _dbContext.InterestType.FirstOrDefault(x => x.Id == interestTypeId);
            if (interestType == null) throw new ElementNotFoundException("A interest type with such an ID does not exist.");
            ActivityEntity newInterest = new ActivityEntity{ Name = name, InterestType = interestType }; 
            _dbContext.Add(newInterest);
            _dbContext.SaveChanges();
            return newInterest;
        }
        public List<ActivityEntity> GetAllInterest()
        {
            return _dbContext.Activities
                .Include(x => x.InterestType)
                .ToList();
        }
        public ActivityEntity UpdateInterest(Guid id, string? name, Guid? interestTypeId) {
            var interest = _dbContext.Activities
                .Include(x => x.InterestType)
                .First(x => x.Id == id);
            if (interest == null) throw new ElementNotFoundException("A interest with such an ID does not exist.");
            interest.Name = name ?? interest.Name;

            if(interestTypeId != null)
            {
                var interestType = _dbContext.InterestType.FirstOrDefault(x => x.Id == interestTypeId);
                if (interestType == null) throw new ElementNotFoundException("A interest type with such an ID does not exist.");
                interest.InterestType = interestType;
            }

            _dbContext.SaveChanges();
            return interest;
        }
        public void DeleteInterest(Guid interestId) {

            var interest = _dbContext.Activities
               .FirstOrDefault(x => x.Id == interestId);
            if (interest == null) throw new ElementNotFoundException("A interest with such an ID does not exist.");

            var userCurentInterest = _dbContext.UserInterest.Where(x => x.InterestId == interestId);
            _dbContext.UserInterest.RemoveRange(userCurentInterest);

            _dbContext.Activities.Remove(interest);

            _dbContext.SaveChanges();
        }
    }
}
