using DengueLearn.Data;
using DengueLearn.Models;
using DengueLearn.Repository.Interfaces;

namespace DengueLearn.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DengueLearnDbContext _dbContext;

        public VideoRepository(DengueLearnDbContext context)
        {
            _dbContext = context;
        }

        public VideoModel GetVideoById(long id)
        {
            return _dbContext.Video.FirstOrDefault(x => x.Id == id);
        }
    }
}
