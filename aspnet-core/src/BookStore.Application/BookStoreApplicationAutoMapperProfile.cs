using AutoMapper;
using BookStore.Books;

namespace BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            // map thực thể sách thành DTO sách để bind lên UI
            CreateMap<Book, BookDto>();

            // map thông tin sách cần thêm hoặc sửa thành thực thể sách
            CreateMap<CreateUpdateBookDto, Book>();
        }
    }
}
