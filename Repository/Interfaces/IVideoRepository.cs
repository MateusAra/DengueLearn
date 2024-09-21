using DengueLearn.Models;

namespace DengueLearn.Repository.Interfaces
{
    public interface IVideoRepository
    {
        VideoModel GetVideoById(long id);
    }
}
