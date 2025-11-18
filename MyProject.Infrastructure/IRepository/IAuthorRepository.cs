using MyProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.IRepository
{
    public
    interface IAuthorRepository 
    {
        Task<Author> GetByIdAsync (int id);
        Task<Author> GetByNameAsync(string name);
        Task<List<Author>> GetAllAsync();
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(Author author);
    }
}
