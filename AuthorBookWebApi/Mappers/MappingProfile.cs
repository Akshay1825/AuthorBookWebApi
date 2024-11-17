using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Models;
using AutoMapper;

namespace AuthorBookWebApi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Author, AuthorDTO>()
                .ForMember(destination => destination.TotalBooks, value => value.MapFrom(source => source.Books.Count()));
            CreateMap<AuthorDTO, Author>();
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<AuthorDetailsDTO, AuthorDetails>();
            CreateMap<AuthorDetails, AuthorDetailsDTO>();
        }
    }
}
