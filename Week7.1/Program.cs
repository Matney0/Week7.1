
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JsonSerializerHelper.JsonConvert;  
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    // Constructor
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
}
// Helper class to serialize and deserialize a book object
public class JsonSerializerHelper
{
    public class JsonConvert
    {
        public static string SerializeObject(Book book)
        {
            return $"{{\"Title\":\"{book.Title}\",\"Author\":\"{book.Author}\",\"Year\":{book.Year}}}";
        }
        public static Book DeserializeObject(string json)
        {
            //get the parts of the json string
            string[] parts = json.Split(',');
            string title = parts[0].Split(':')[1].Trim('"');
            string author = parts[1].Split(':')[1].Trim('"');
            int year = int.Parse(parts[2].Split(':')[1]);
            return new Book(title, author, year);
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a book object
        Book myBook = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925);

        // Specify the file name to save the serialized book
        string fileName = "book.json";

        // Serialize the book object to a JSON file
        JsonSerializerHelper.SerializeToJson(fileName, myBook);

        // Deserialize the book 
        Book deserializedBook = JsonSerializerHelper.DeserializeFromJson(fileName);

        // Display book details
        if (deserializedBook != null)
        {
            Console.WriteLine($"Book Title: {deserializedBook.Title}");
            Console.WriteLine($"Author: {deserializedBook.Author}");
            Console.WriteLine($"Year: {deserializedBook.Year}");
        }
    }
}

