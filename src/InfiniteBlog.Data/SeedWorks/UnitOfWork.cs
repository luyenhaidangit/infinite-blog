using AutoMapper;
using InfiniteBlog.Core.Domain.Content;
using InfiniteBlog.Core.Repositories;
using InfiniteBlog.Core.SeedWorks;
using InfiniteBlog.Data.Repositories;

namespace InfiniteBlog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InfiniteBlogContext _context;

        public IPostRepository Posts { get; private set; }

        public UnitOfWork(InfiniteBlogContext context, IMapper mapper)
        {
            _context = context;
            Posts = new PostRepository(context, mapper);
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}