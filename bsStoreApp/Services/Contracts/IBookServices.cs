using Entities;
using Entities.DataTranferObjcets;
using Entities.LinkModels;
using Entities.RequestFeatures;
using Entities.ResquestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookServices
    {
        Task<(LinkResponse linkResponse, MetaDeta MetaDeta)> GetAllBooksAsync(lLinkParameters linkParameters,
            bool trackChanges);
        Task<BookDto> GetOneBookIdAsync(int id,bool trackChanges);
        Task<BookDto> CreateOneBookAsync(BookDtoForInsertion book);
        Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges);
        Task DeleteOneBookAsync(int id,bool trackChanges);
        Task<(BookDtoForUpdate bookDtoForUpdate,Book book)> GetOneBookForPatchAsync(int id,bool trackChanges);
        Task SaveChangesForUpdateAsync(BookDtoForUpdate bookDtoForUpdate, Book book);    
    }
}
