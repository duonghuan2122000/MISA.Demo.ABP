using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BookStore.Books
{
    /// <summary>
    /// DTO sách (DTO: data transfer object)
    /// CreatedBy: dbhuan 25/05/2021
    /// </summary>
    public class BookDto: AuditedEntityDto<Guid>
    {
        /// <summary>
        /// Tên sách
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Loại sách
        /// </summary>
        public BookType Type { get; set; }

        /// <summary>
        /// ngày xuất bản
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// giá sách
        /// </summary>
        public float Price { get; set; }
    }
}
