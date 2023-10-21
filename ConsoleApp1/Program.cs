using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{

    public class PublishingHouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }

    public class Book
    {
        [JsonIgnore]
        public int PublishingHouseId { get; set; }

        [JsonProperty("Name")]
        public string Title { get; set; }

        public PublishingHouse PublishingHouse { get; set; }
    }

    public class BookService
    {
        public List<Book> LoadBooks(string filePath) 
        {
            try {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Book>>(json); 
            } 
            catch
            { 
                Console.WriteLine("file not found " + filePath);
                return null;
            }
           
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BookService bookService = new BookService();
            List<Book> books = bookService.LoadBooks("path_to_file.json");

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
