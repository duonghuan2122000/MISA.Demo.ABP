using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Books
{
    /// <summary>
    /// Thông tin sách
    /// CreatedBy: dbhuan 25/05/2021
    /// </summary>
    public class Book: AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Tên sách
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// loại sách
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
