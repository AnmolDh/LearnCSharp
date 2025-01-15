using System.Text.Json;

namespace LMS
{
    internal class Run
    {
        public static async Task AddBook()
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine() ?? "Unknown";
                Console.Write("Enter Author: ");
                string author = Console.ReadLine() ?? "Unknown";
                Console.Write("Enter ISBN: ");
                string isbn = Console.ReadLine() ?? "Unknown";
                Console.Write("Enter Nos: ");
                int nos = Convert.ToInt32(Console.ReadLine());

                Book createEntry = new(title, author, isbn, nos);
                Program.database.Add(createEntry);

                await Task.Run(SaveBooks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async Task RemoveBook()
        {
            try
            {
                Book btr = SearchBook();
                if (btr == null) return;
                Program.database.Remove(btr);

                await Task.Run(SaveBooks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static Book SearchBook()
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine() ?? "Unknown";

                foreach (var b in Program.database)
                {
                    Console.WriteLine($"{b.Title} - {b.Author} ({b.ISBN})");
                    if (b.Title == title) return b;
                }
            } 
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return null;
        }

        public static void ViewBooks()
        {
            int sno = 0;
            foreach (var b in Program.database)
            {
                Console.WriteLine($"{sno++}: {b.Title} - {b.Author} ({b.ISBN})");
            }
        }

        static void SaveBooks()
        {
            string path = @"D:\Dev\C#\LMS\bin\data.json";
            string json = JsonSerializer.Serialize(Program.database);
            File.WriteAllTextAsync(path, json);
        }
    }
}
