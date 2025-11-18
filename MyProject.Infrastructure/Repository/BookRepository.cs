using Microsoft.EntityFrameworkCore;
using MyProject.Core;
using MyProject.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context) 
        {
            _context = context;
        }
        
        public async Task AddAsync(Book book) /// Ассинхроность "Async" важно для синхронного програмирования
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
           return await _context.Books
            .Include(b => b.AuthorBooks)
                .ThenInclude(ba => ba.Author)
            .ToListAsync();
            
        }

        public async Task<Book?> GetByIdAsync(int id)
        => await _context.Books
            .Include(b => b.AuthorBooks)
                .ThenInclude(ba => ba.Author)
            .FirstOrDefaultAsync(b => b.Id == id);
        public async Task<Book?> GetByNameAsync(string name)
        => await _context.Books
            .Include(b => b.AuthorBooks)
                .ThenInclude(ba => ba.Author)
            .FirstOrDefaultAsync(b => b.Title == name);

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

    }
}
