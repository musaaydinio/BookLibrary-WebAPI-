using Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Contracts;
using Entities.Exceptions;
using AutoMapper;
using Entities.DataTranferObjcets;
using Entities.ResquestFeatures;

namespace Services
{
    public class BookManager : IBookServices
    {
        private readonly ILoggerService _logger;
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<BookDto>CreateOneBookAsync(BookDtoForInsertion bookdto)
        {
            var entity=_mapper.Map<Book>(bookdto);
            _manager.Book.CreateOneBook(entity);
           await _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
           var entity=await GetOneBookByIdAndCheckExists(id, trackChanges);           
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(BookPrametrs bookPrametrs, bool trackChanges)
        {
           var books= await _manager.Book.GetAllBookAsync(bookPrametrs, trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var book=await GetOneBookByIdAndCheckExists(id,trackChanges);
            var bookDtoForUpdate=_mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);
        }

        public async Task<BookDto> GetOneBookIdAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookByIdAndCheckExists(id, trackChanges);
            return _mapper.Map<BookDto>(book);
        }

        public async Task SaveChangesForUpdateAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            _mapper.Map(bookDtoForUpdate, book);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookdto, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExists(id, trackChanges);
             entity=_mapper.Map<Book>(bookdto);
            _manager.Book.UpdateOneBook(entity);
            await _manager.SaveAsync();
        }
        private async Task<Book> GetOneBookByIdAndCheckExists(int id,bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (entity is null)
                throw new BookNotFoundException(id);
            return entity;
        }
    }
}
