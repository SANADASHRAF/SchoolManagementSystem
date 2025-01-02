using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges);
        Task<BookDto> GetBookByIdAsync(long bookId, bool trackChanges);
        Task<IEnumerable<BookDto>> GetBooksByTermAndYearAsync(int termId, int academicYearId, bool trackChanges);
        Task<BookDto> CreateBookAsync(BookForCreationDto bookDto);
        Task DeleteBookAsync(long bookId);
    }
}
