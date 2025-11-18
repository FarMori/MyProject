using MyProject.Core;
using MyProject.Infrastructure.IRepository;
using MyProject.Infrastructure.Repository;

namespace MyProject.Service
{
    public class BookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;
        public BookService(IBookRepository bookRepo, IAuthorRepository authorRepo) 
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
        }

        public async Task<Book> CreateBookAsync (string title, List<int> authorIds)
        {
            var book = new Book { Title = title };

            foreach (var authorId in authorIds) 
            {
                var author =  await _authorRepo.GetByIdAsync(authorId);
                if (author == null)
                    throw new Exception($"Author with ID {authorId} not found");
                book.AuthorBooks.Add(new AuthorBook { Book = book, Author = author });

            }
            await _bookRepo.AddAsync(book);
            return book;            

        }

    }
}
