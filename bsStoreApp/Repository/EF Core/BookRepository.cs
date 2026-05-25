using Entities;
using Entities.ResquestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF_Core
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoriesContex contex) : base(contex)
        {
            
        }

        public void CreateOneBook(Book book) => Create(book);
       

        public void DeleteOneBook(Book book)=>Delete(book);

        public async Task<IEnumerable<Book>> GetAllBookAsync(BookPrametrs bookPrametrs, bool trackChanges) =>
            await
            FindAll(trackChanges).OrderBy(b => b.Id)
            .Skip((bookPrametrs.PageNumber-1)*bookPrametrs.PageSize)
            .Take(bookPrametrs.PageSize)
            .ToListAsync();


        public async Task <Book> GetOneBookByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
       

        public void UpdateOneBook(Book book)=>Update(book);
       
    }
}
