using System.Text.Json;

namespace LMS
{
    class Program
    {
        public static List<Book> database = new();
        static void Main()
        {
            Console.WriteLine("Welcome to LMS!");

            Task loadBooks = Task.Run(() =>
            {
                string jsonString = File.ReadAllText(@"D:\Dev\C#\LMS\bin\data.json");
                database = JsonSerializer.Deserialize<List<Book>>(jsonString) ?? [];
            });

            do
            {
                try
                {
                    Console.WriteLine("Select operation: (1 -> View / 2 -> Add / 3 -> Remove / 4 -> Search / -1 -> Exit)");
                    int selectedOperation = Convert.ToInt32(Console.ReadLine());
                    if (selectedOperation == -1) return;
                    else if (selectedOperation >= 1 && selectedOperation <= 4)
                    {
                        switch (selectedOperation)
                        {
                            case 1:
                                Run.ViewBooks();
                                break;
                            case 2:
                                Run.AddBook();
                                break;
                            case 3:
                                Run.RemoveBook();
                                break;
                            case 4:
                                Run.SearchBook();
                                break;
                        }
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            while (true);
        }
    }
}