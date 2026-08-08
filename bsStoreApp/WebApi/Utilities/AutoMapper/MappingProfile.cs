using AutoMapper;
using Entities;
using Entities.DataTranferObjcets;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile :Profile    
    {
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>().ReverseMap();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion, Book>();
            CreateMap<UserForResgistrationDto,User>();
        }
    }
}
