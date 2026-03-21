using System;
using System.Collections.Generic;
using Codeflix.Models;
using Codeflix.DataStructures;
using Codeflix.Utils;
using Codeflix.Database;

namespace Codeflix
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CodeflixDB;Trusted_Connection=True;";
            DatabaseManager dbManager = new DatabaseManager(connectionString);

            BinarySearchTree library = new BinarySearchTree();
            int nextId = 1;
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== CODEFLIX =====");
                Console.WriteLine("1. Add Media Item");
                Console.WriteLine("2. Search by Title");
                Console.WriteLine("3. Display All Items");
                Console.WriteLine("4. Delete by Title");
                Console.WriteLine("5. Save All Items to Database");
                Console.WriteLine("6. Load All Items from Database");
                Console.WriteLine("7. Exit");

                string choice = InputValidator.ReadMenuChoice("1", "2", "3", "4", "5", "6", "7");

                switch (choice)
                {
                    case "1":
                        AddMediaItem(library, ref nextId);
                        break;

                    case "2":
                        SearchMediaItem(library);
                        break;

                    case "3":
                        library.DisplayInOrder();
                        break;

                    case "4":
                        DeleteMediaItem(library, dbManager);
                        break;

                    case "5":
                        SaveAllToDatabase(library, dbManager);
                        break;

                    case "6":
                        nextId = LoadAllFromDatabase(library, dbManager);
                        break;

                    case "7":
                        running = false;
                        Console.WriteLine("Exiting Codeflix...");
                        break;
                }
            }
        }

        static void AddMediaItem(BinarySearchTree library, ref int nextId)
        {
            Console.WriteLine("\n--- Add Media Item ---");

            string title = InputValidator.ReadRequiredString("title");
            string genre = InputValidator.ReadRequiredString("genre");
            int releaseYear = InputValidator.ReadInt("release year", 1888, 2100);
            string type = InputValidator.ReadMediaType();
            double rating = InputValidator.ReadDouble("rating", 0, 10);
            string director = InputValidator.ReadRequiredString("director");

            MediaItem item = new MediaItem(nextId, title, genre, releaseYear, type, rating, director);

            bool inserted = library.Insert(item);

            if (inserted)
            {
                nextId++;
                Console.WriteLine("Media item added successfully.");
            }
            else
            {
                Console.WriteLine("An item with this title already exists.");
            }
        }

        static void SearchMediaItem(BinarySearchTree library)
        {
            Console.WriteLine("\n--- Search Media Item ---");

            string title = InputValidator.ReadRequiredString("title to search");
            MediaItem foundItem = library.Search(title);

            if (foundItem != null)
            {
                Console.WriteLine("Item found:");
                Console.WriteLine(foundItem);
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        static void DeleteMediaItem(BinarySearchTree library, DatabaseManager dbManager)
        {
            Console.WriteLine("\n--- Delete Media Item ---");

            string title = InputValidator.ReadRequiredString("title to delete");

            bool deletedFromMemory = library.Delete(title);
            bool deletedFromDatabase = dbManager.DeleteMediaItemByTitle(title);

            if (deletedFromMemory || deletedFromDatabase)
            {
                Console.WriteLine("Item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Item not found in memory or database.");
            }
        }

        static void SaveAllToDatabase(BinarySearchTree library, DatabaseManager dbManager)
        {
            Console.WriteLine("\n--- Save All Items to Database ---");

            List<MediaItem> items = library.GetAllItems();

            if (items.Count == 0)
            {
                Console.WriteLine("No items in memory to save.");
                return;
            }

            int savedCount = 0;
            int skippedCount = 0;

            foreach (MediaItem item in items)
            {
                if (dbManager.MediaItemExists(item.Title))
                {
                    skippedCount++;
                    continue;
                }

                bool saved = dbManager.InsertMediaItem(item);

                if (saved)
                {
                    savedCount++;
                }
            }

            Console.WriteLine($"{savedCount} item(s) saved to database.");
            Console.WriteLine($"{skippedCount} item(s) skipped because they already exist in database.");
        }

        static int LoadAllFromDatabase(BinarySearchTree library, DatabaseManager dbManager)
        {
            Console.WriteLine("\n--- Load All Items from Database ---");

            List<MediaItem> items = dbManager.GetAllMediaItems();

            if (items.Count == 0)
            {
                Console.WriteLine("No items found in database.");
                return 1;
            }

            library.Clear();

            int maxId = 0;

            foreach (MediaItem item in items)
            {
                library.Insert(item);

                if (item.Id > maxId)
                {
                    maxId = item.Id;
                }
            }

            Console.WriteLine($"{items.Count} item(s) loaded into memory from database.");

            return maxId + 1;
        }
    }
}