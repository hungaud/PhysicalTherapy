using PhysicalTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Repositories
{
    public interface IPostRoutineSurveyRepository
    {
        Task<PostRoutineSurvey> Add(PostRoutineSurvey postRoutineSurvey);
    }
    public class PostRoutineSurveyRepository : IPostRoutineSurveyRepository
    {
        private PhysicalTherapyContext _context;

        public PostRoutineSurveyRepository(PhysicalTherapyContext context)
        {
            _context = context;
        }

        public async Task<PostRoutineSurvey> Add(PostRoutineSurvey postRoutineSurvey)
        {
            _context.PostRoutineSurveys.Add(postRoutineSurvey);
            await _context.SaveChangesAsync();
            return postRoutineSurvey;
        }
    }
}
