using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF_Core
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books,uint minPrice,
            uint maxPrice)=>books.Where(book=>(book.Price>=minPrice)&&
            (book.Price<=maxPrice));

    }
}
