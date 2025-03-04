using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

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

public class JsonSerializerHelper
{
    // Method to serialize a Book object to JSON and save it in a file
    public static void SerializeToJson(string fileName, Book book)
    {
        try
        {
            //Serialize the book object to a JSON string
            string json = JsonConvert.SerializeObject(book);

            // Write the JSON string to the specified file
            File.WriteAllText(fileName, json);
            Console.WriteLine($"Book details serialized and saved to {fileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while serializing the book: {ex.Message}");
        }
    }

    // Method to deserialize the JSON file back into a Book object
    public static Book DeserializeFromJson(string fileName)
    {
        try
        {
            // Read the JSON string from the file
            string json = File.ReadAllText(fileName);

            // Deserialize the JSON string back into a Book object
            Book book = JsonConvert.DeserializeObject<Book>(json);
            Console.WriteLine("Book details deserialized successfully.");
            return book;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while deserializing the book: {ex.Message}");
            return null;
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

        // Deserialize the book object from the JSON file
        Book deserializedBook = JsonSerializerHelper.DeserializeFromJson(fileName);

        // Display the deserialized book details
        if (deserializedBook != null)
        {
            Console.WriteLine($"Book Title: {deserializedBook.Title}");
            Console.WriteLine($"Author: {deserializedBook.Author}");
            Console.WriteLine($"Year: {deserializedBook.Year}");
        }
    }
}
