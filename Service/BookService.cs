using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Repository;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public BookService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _repository.Book.GetAllBooksAsync(trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(long bookId, bool trackChanges)
        {
            var book = await _repository.Book.GetBookByIdAsync(bookId, trackChanges);
            if (book == null)
                throw new Exception($"Book with id {bookId} not found");

            return _mapper.Map<BookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByTermAndYearAsync(int termId, int academicYearId, bool trackChanges)
        {
            var books = await _repository.Book.GetBooksByTermAndYearAsync(termId, academicYearId, trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> CreateBookAsync(BookForCreationDto bookDto)
        {
            var filePath = await _repository.Book.UploadBookFile(bookDto.BookFile);

            var bookEntity = _mapper.Map<Book>(bookDto);
            bookEntity.BookFilePath = filePath;

            _repository.Book.CreateBook(bookEntity);
            _repository.Save();

            return _mapper.Map<BookDto>(bookEntity);
        }

        public async Task DeleteBookAsync(long bookId)
        {
            var book = await _repository.Book.GetBookByIdAsync(bookId, trackChanges: false);
            if (book == null)
                throw new Exception($"Book with id {bookId} not found");

            book.Isdeleted = true;
            _repository.Save();
        }
  

    }
}
