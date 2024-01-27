using InfiniteBlog.Core.Domain.Content;
using InfiniteBlog.Core.SeedWorks;

namespace InfiniteBlog.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
    }
}
