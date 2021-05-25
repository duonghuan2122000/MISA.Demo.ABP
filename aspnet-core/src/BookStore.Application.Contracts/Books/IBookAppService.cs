using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Books
{
    /// <summary>
    /// Interface Service sách
    /// CreatedBy: dbhuan 25/05/2021
    /// </summary>
    public interface IBookAppService: ICrudAppService<BookDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookDto>
    {
    }
}
