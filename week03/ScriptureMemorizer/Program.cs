// Added BooksAndChapters usage to get random verses
// User get a list of 10 random scriptures.

using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        // get a random verse from BooksAndChapters.GetVerses()
        var verses = BooksAndChapters.GetVerses();
        Random rand = new Random();
        int index = rand.Next(verses.Count);
        var (reference, text) = verses[index];
        Scripture scripture = new Scripture(reference, text);
        // Reference reference = new Reference("Proverbs", 3, 5, 6);
        // Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        while (!scripture.isCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(reference.GetDisplayText());
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWord(2);
        }
        if (scripture.isCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(reference.GetDisplayText());
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden. Well done!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine(reference.GetDisplayText());
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden. Well done!");
        }
      
    }
}