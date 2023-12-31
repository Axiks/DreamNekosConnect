﻿using DreamNekosConnect.Lib.Entities;
using DreamNekosConnect.Lib.Providers;
using Microsoft.EntityFrameworkCore;

namespace DreamNekosConnect.Lib.Services
{
    public class InterestTypeService
    {
        private ApplicationDbContext _dbContext { get; set; }
        public InterestTypeService()
        {
            var dbProvider = DbProvider.GetInstance();
            _dbContext = dbProvider.GetDbContext();
        }
        public InterestTypeEntity CreateInterestType(string name)
        {
            var newInterestType = new InterestTypeEntity { Name = name };
            _dbContext.Add(newInterestType);
            _dbContext.SaveChanges();
            return newInterestType;
        }
        public InterestTypeEntity GetInterestType(Guid interestId)
        {
            var interestType = _dbContext.InterestType
                .Include(x => x.Interests)
                .FirstOrDefault(x => x.Id == interestId);
            return interestType;
        }
        public List<InterestTypeEntity> GetAllInterestType()
        {
            var interestType = _dbContext.InterestType;
            return interestType.ToList();
        }
        public InterestTypeEntity UpdateInterestType(Guid interestId, string? name)
        {
            var interestType = _dbContext.InterestType.FirstOrDefault(x => x.Id == interestId);
            if (name != null) interestType.Name = name;
            _dbContext.SaveChanges();
            return interestType;
        }
        public void DeleteInterestType(Guid interestId)
        {
            var interestType = _dbContext.InterestType.FirstOrDefault(x => x.Id == interestId);
            _dbContext.Remove(interestType);
            _dbContext.SaveChanges();
        }
    }
}
