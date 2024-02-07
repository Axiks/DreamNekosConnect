using DreamNekos.Core.Models;
using DreamNekosConnect.Lib.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamNekosConnect.Lib.Services
{
    public class StatisticService
    {
        private ApplicationDbContext _dbContext { get; set; }

        public StatisticService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int TotalUsers() {
            return _dbContext.Users.Count();
        }

        public async Task<List<InterestPopularityByTypeResponse>> PopularityByTypeAsync()
        {
            List<InterestPopularityByTypeResponse> interestPopularityByTypeList = new List<InterestPopularityByTypeResponse>();

            foreach(var interestType in await _dbContext.InterestType.ToListAsync())
            {
                List<InterestPopularityResponse> interestPopularities = new List<InterestPopularityResponse>();

                var interests = await GetInterestsForType(interestType.Id);
                foreach(var interest in interests)
                {
                    var score = await HowMuchUserHaveThisInterest(interest.Id);
                    InterestPopularityResponse interestPopularity = new InterestPopularityResponse() {
                        Score = score,
                        InterestId = interest.Id,
                        InterestName = interest.Name,
                    };
                    interestPopularities.Add(interestPopularity);
                }

                InterestPopularityByTypeResponse interestPopularityByType = new InterestPopularityByTypeResponse() {
                    TypeId = interestType.Id,
                    TypeName = interestType.Name,
                    InterestPopularityList = interestPopularities
                };
                interestPopularityByTypeList.Add(interestPopularityByType);
            };

            async Task<List<InterestsDTO>> GetInterestsForType(Guid InterestTypeId)
            {
                return await _dbContext.Interests.Where(x => x.InterestTypeId == InterestTypeId).Select(x => new InterestsDTO(x.Id, x.Name)).ToListAsync();
            }

            async Task<int> HowMuchUserHaveThisInterest(Guid InterestId)
            {
                return await _dbContext.UserInterest.Where(x => x.InterestId == InterestId).CountAsync();
            }
            return interestPopularityByTypeList;
        }
    }
}

public class InterestsDTO
{
    public InterestsDTO(Guid id, String name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }
}
