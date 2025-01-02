using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetBookByIdAsync(long bookId, bool trackChanges);
        Task<IEnumerable<Book>> GetBooksByTermAndYearAsync(int termId, int academicYearId, bool trackChanges);
        void CreateBook(Book book);
        Task<string> UploadBookFile(IFormFile file); 
    }
}
