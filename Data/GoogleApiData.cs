using Google.Apis.Services;
using Google.Apis.Books.v1;
using System.Linq;
using System.Collections.Generic;
using BookApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookApi.Data
{
    public class GoogleApiData
    {
        private readonly static string APIKEY = "AIzaSyAUpj-xGF0wYWYaFsHxHTFzdi0iGTSHC4A";
        private readonly static string SEARCHSTRING = "Harry Potter";

        public BooksService service;
        public GoogleApiData()
        {
            service = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = APIKEY,
                ApplicationName = this.GetType().ToString()
            });
        }
        public void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<BookContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // Look for any books
            if (context.Books != null && context.Books.Any())
               
                return;   // DB has already been seeded
           
            var books = GetBooks().ToArray();
            
            context.Books.AddRange(books);
            context.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            var listQuery = service.Volumes.List(SEARCHSTRING);

            listQuery.MaxResults = 40;

            var res = listQuery.Execute();

                List<Book> books = res.Items.Select(b => new Book
                {
                    ISBN_10 = b.VolumeInfo.IndustryIdentifiers[0].Type.Contains("ISBN_10") ? b.VolumeInfo.IndustryIdentifiers[0].Identifier : b.VolumeInfo.IndustryIdentifiers[1].Identifier,
                    Title = b.VolumeInfo.Title ?? "",
                    SmallThumbnail = b.VolumeInfo.ImageLinks.SmallThumbnail ?? "",
                    Authors = (b.VolumeInfo.Authors != null) ? b.VolumeInfo.Authors[0] : "",
                    Publisher = b.VolumeInfo.Publisher ?? "",
                    PublishedDate = b.VolumeInfo.PublishedDate ?? "",
                    Description = b.VolumeInfo.Description ?? "",
                }).ToList();

            return books;        
        }
    }
}
