using DreamNekosConnect.Lib.Entities;
using DreamNekosConnect.Lib.Providers;
using Microsoft.EntityFrameworkCore;

namespace DreamNekosConnect.Lib.Services
{
    public class InterestService
    {
        private ApplicationDbContext _dbContext { get; set; }
        public InterestService(ApplicationDbContext applicationDbContext)
        {
            /*var dbProvider = DbProvider.GetInstance();
            _dbContext = dbProvider.GetDbContext();*/
            _dbContext = applicationDbContext;
        }

        public InterestEntity CreateInterest(string name, Guid? interestTypeId)
        {
            var interestType = _dbContext.InterestType.FirstOrDefault(x => x.Id == interestTypeId);
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
            interest.Name = name ?? interest.Name;

            if(interestTypeId != null)
            {
                var interestType = _dbContext.InterestType.FirstOrDefault(x => x.Id == interestTypeId);
                interest.InterestType = interestType;
            }

            _dbContext.SaveChanges();
            return interest;
        }
        public void DeleteInterest(InterestEntity interest) {
            _dbContext.Interests.Remove(interest);
            _dbContext.SaveChanges();
        }
    }
}
