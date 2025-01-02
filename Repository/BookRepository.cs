using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges) =>
        await FindAll(trackChanges)
             .Where(x=>x.Isdeleted==false)
             .ToListAsync();

        public async Task<Book> GetBookByIdAsync(long bookId, bool trackChanges) =>
            await FindByCondition(b => b.BookId == bookId, trackChanges)
                 .Where(x => x.Isdeleted == false)
                 .SingleOrDefaultAsync();

        public async Task<IEnumerable<Book>> GetBooksByTermAndYearAsync(int termId, int academicYearId, bool trackChanges) =>
            await FindByCondition(b => b.TermID == termId && b.AcademicYearID == academicYearId, trackChanges)
                 .Where(x => x.Isdeleted == false)
                 .ToListAsync();

        public async void CreateBook(Book book) => Create(book);

        public async Task<string> UploadBookFile(IFormFile file)
        {
            try
            {
                string directory = @"h:\root\home\hattanfjh-001\www\hawisports\wwwroot\books\";

                CheckDirectoryExist(directory);

                var path = Path.Combine(directory, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return path; 
            }
            catch (Exception ex)
            {
                return $"Error uploading book file: {ex.Message}";
            }
        }

        public void CheckDirectoryExist(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

    }
}
