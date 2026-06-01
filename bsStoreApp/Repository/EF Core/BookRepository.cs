using Entities;
using Entities.RequestFeatures;
using Entities.ResquestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.EF_Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF_Core
{
    public sealed class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoriesContex contex) : base(contex)
        {
            
        }

        public void CreateOneBook(Book book) => Create(book);
       

        public void DeleteOneBook(Book book)=>Delete(book);

        public async Task<PagedList<Book>> GetAllBookAsync(BookPrametrs bookPrametrs, bool trackChanges)
        {

           var books= await
            FindAll(trackChanges)
           .FilterBooks(bookPrametrs.MinPrice,bookPrametrs.MaxPrice)
           .Search(bookPrametrs.SearchTerm)
           .OrderBy(b => b.Id)
           .ToListAsync();

            return PagedList<Book>.ToPagedList(books,
                bookPrametrs.PageNumber,bookPrametrs.PageSize);
        }
           
        public async Task <Book> GetOneBookByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
       

        public void UpdateOneBook(Book book)=>Update(book);
       
    }
}
