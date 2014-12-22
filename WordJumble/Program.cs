using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WordJumble
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Word Jumble Solver!");
            Console.WriteLine("Please give the path of the word list you'd like to use,");
            Console.WriteLine("or hit enter to use the default word list.");
            var wordFile = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(wordFile)) {
            var info = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var dir = info.Parent.Parent.FullName;
            wordFile = Path.Combine(dir, "words.txt");
            }
            var trie = new Trie(wordFile);
            Console.WriteLine("Dictionary has been loaded.");
            var input = string.Empty;
            while (true)
            {
                Console.WriteLine("Please enter text to solve or 'exit' to stop the application.");
                input = Console.ReadLine();
                if (input.ToLower() != "exit")
                {
                    var results = trie.GetWords(input);
                    Console.WriteLine(string.Format("The solver returned {0} results:", results.Count()));
                    foreach (var result in results)
                    {
                        Console.WriteLine(result);
                    }
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
