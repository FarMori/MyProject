using MyProject.Core;
using MyProject.Infrastructure.IRepository;

namespace MyProject.Service
{
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepo;
        public AuthorService(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }
        public async Task<Author> GetByIdAsync(int id)
        {
            return await _authorRepo.GetByIdAsync(id);
        }

        public async Task<Author> GetByNameAsync(string name)
        {
            return await _authorRepo.GetByNameAsync(name);
        }
        public async Task<Author> CreateAuthorAsync(string name )
        {
            var author = new Author { FullName = name };
            await _authorRepo.AddAsync( author );  
            return author;
         }

    }
}
