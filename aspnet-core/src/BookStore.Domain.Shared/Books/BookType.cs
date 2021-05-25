using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Books
{
    /// <summary>
    /// Thông tin các loại sách
    /// CreatedBy: dbhuan 25/05/2021
    /// </summary>
    public enum BookType
    {
        /// <summary>
        /// không xác định
        /// </summary>
        Undefined,

        /// <summary>
        /// thám hiểm
        /// </summary>
        Adventure,

        /// <summary>
        /// địa lý
        /// </summary>
        Biography,

        /// <summary>
        /// 
        /// </summary>
        Dystopia,

        /// <summary>
        /// trinh thám
        /// </summary>
        Fantastic,

        /// <summary>
        /// kinh dị
        /// </summary>
        Horror,

        /// <summary>
        /// khoa học
        /// </summary>
        Science,

        /// <summary>
        /// khoa học viễn tưởng
        /// </summary>
        ScienceFiction,

        /// <summary>
        /// sách thơ
        /// </summary>
        Poetry
    }
}
