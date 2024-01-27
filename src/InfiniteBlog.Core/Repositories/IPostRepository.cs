using InfiniteBlog.Core.Domain.Content;
using InfiniteBlog.Core.Models.Content;
using InfiniteBlog.Core.Models;
using InfiniteBlog.Core.SeedWorks;

namespace InfiniteBlog.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);

        Task<PagedResult<PostInListDto>> GetPostsPagingAsync(string keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
    }
}
