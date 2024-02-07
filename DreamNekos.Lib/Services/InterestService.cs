using DreamNekos.API.Helpers;
using DreamNekosConnect.Lib.Entities;
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

        public InterestEntity CreateInterest(string name, Guid? interestTypeId)
        {
            var interestType = _dbContext.InterestType.FirstOrDefault(x => x.Id == interestTypeId);
            if (interestType == null) throw new ElementNotFoundException("A interest type with such an ID does not exist.");
            InterestEntity newInterest = new InterestEntity{ Name = name, InterestType = interestType }; 
            _dbContext.Add(newInterest);
            _dbContext.SaveChanges();
            return newInterest;
        }
        public List<InterestEntity> GetAllInterest()
        {
            return _dbContext.Interests
                .Include(x => x.InterestType)
                .ToList();
        }
        public InterestEntity UpdateInterest(Guid id, string? name, Guid? interestTypeId) {
            var interest = _dbContext.Interests
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

            var interest = _dbContext.Interests
               .FirstOrDefault(x => x.Id == interestId);
            if (interest == null) throw new ElementNotFoundException("A interest with such an ID does not exist.");

            var userCurentInterest = _dbContext.UserInterest.Where(x => x.InterestId == interestId);
            _dbContext.UserInterest.RemoveRange(userCurentInterest);

            _dbContext.Interests.Remove(interest);

            _dbContext.SaveChanges();
        }
    }
}
