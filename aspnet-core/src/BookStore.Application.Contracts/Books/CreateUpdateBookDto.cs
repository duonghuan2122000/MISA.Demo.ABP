using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Books
{
    /// <summary>
    /// DTO thêm và sửa sách
    /// CreatedBy: dbhuan 25/05/2021
    /// </summary>
    public class CreateUpdateBookDto
    {
        /// <summary>
        /// tên sách
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// loại sách
        /// </summary>
        [Required]
        public BookType Type { get; set; } = BookType.Undefined;

        /// <summary>
        /// ngày xuất bản
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        /// <summary>
        /// giá sách
        /// </summary>
        [Required]
        public float Price { get; set; }
    }
}
