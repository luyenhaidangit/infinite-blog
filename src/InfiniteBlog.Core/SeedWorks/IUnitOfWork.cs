using InfiniteBlog.Core.Repositories;

namespace InfiniteBlog.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }

        Task<int> CompleteAsync();
    }
}