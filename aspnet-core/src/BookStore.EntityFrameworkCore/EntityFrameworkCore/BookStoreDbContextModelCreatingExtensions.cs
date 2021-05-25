using BookStore.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BookStore.EntityFrameworkCore
{
    public static class BookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureBookStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            // cấu hình bảng sách trên db
            builder.Entity<Book>(b =>
            {
                // tên bảng
                b.ToTable(BookStoreConsts.DbTablePrefix + "Books", BookStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props

                // vaidation
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });
        }
    }
}