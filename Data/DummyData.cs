using BookApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Data
{
    public class DummyData
    {
        //This class was only used for initial construction of database and is no longer in use
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<BookContext>();
            context.Database.EnsureCreated();

            // Look for any books
            if (context.Books != null && context.Books.Any())
                return;   // DB has already been seeded

            var books = DummyData.GetBooks().ToArray();
            context.Books.AddRange(books);
            context.SaveChanges();
        }

        public static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>() {
                new Book {Title="Head Ache",SmallThumbnail="abcde", Authors="abcde", Publisher="abcde",PublishedDate="Jan 1 2010",Description="abcde", ISBN_10="12345"},
                new Book {Title="Tummy Pain",SmallThumbnail="abcde", Authors="abcde", Publisher="abcde",PublishedDate="Jan 1 2010",Description="abcde", ISBN_10="12346"},
                new Book {Title="Flu",SmallThumbnail="abcde", Authors="abcde", Publisher="abcde",PublishedDate="Jan 1 2010",Description="abcde", ISBN_10="12347"},
                new Book {Title="Cold",SmallThumbnail="abcde", Authors="abcde", Publisher="abcde",PublishedDate="Jan 1 2010",Description="abcde", ISBN_10="12348"},
                new Book {Title="Harry Potter and the Philosopher's Stone", SmallThumbnail="http://books.google.com/books/content?id=39iYWTb6n6cC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",Authors="J.K. Rowling",Publisher="Pottermore Publishing",PublishedDate="2015-12-08",Description="\"Turning the envelope over, his hand trembling, Harry saw a purple wax seal bearing a coat of arms; a lion, an eagle, a badger and a snake surrounding a large letter 'H'.\" Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!",ISBN_10="1781100217"}
            };
            return books;
        }
    }
}


