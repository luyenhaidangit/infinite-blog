using InfiniteBlog.Core.SeedWorks;

namespace InfiniteBlog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InfiniteBlogContext _context;

        public UnitOfWork(InfiniteBlogContext context)
        {
            _context = context;
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