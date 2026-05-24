using AutoMapper;
using Entities;
using Entities.DataTranferObjcets;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile :Profile    
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>().ReverseMap();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion, Book>();
        }
    }
}
