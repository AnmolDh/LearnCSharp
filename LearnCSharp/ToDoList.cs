namespace LearnCSharp
{
    internal class ToDoList
    {
        static string[] View(string path, bool print)
        {
            //using StreamReader sr = new(path);
            //string fileData = sr.ReadToEnd();
            //Console.WriteLine(fileData);

            string[] fileData = File.ReadAllLines(path);

            if (print)
            {
                Console.WriteLine("Your tasks:");
                foreach (var line in fileData)
                {
                    Console.WriteLine(line);
                }
            }

            return fileData;
        }

        static void Add(string path, bool append)
        {
            Console.WriteLine("Add task:");
            string enteredTask = Console.ReadLine();

            using StreamWriter sw = new(path, append: append);
            sw.WriteLine(enteredTask);
        }

        static void Delete(string path)
        {
            int taskNum;
            int.TryParse(Console.ReadLine(), out taskNum);
            string[] fileData = View(path, false);
            int lineCount = 0;

            string s = "";

            foreach (var line in fileData)
            {
                lineCount++;
                if (lineCount != taskNum) s += line + "\n";
            }

            using StreamWriter sw = new(path);
            sw.WriteLine(s);
        }

        public static void RunTODO()
        {
            string path = @"D:\Dev\test.txt";

            do
            {
                Console.WriteLine(@"Select operation:
            View   ->  1
            Add    ->  2
            Delete ->  3
            Exitt  -> -1");

                int selectedOperation;
                do
                {
                    int.TryParse(Console.ReadLine(), out selectedOperation);
                    if (selectedOperation == -1) return;
                    if (selectedOperation >= 1 && selectedOperation <= 3) break;
                    else Console.WriteLine("Select valid operation!");
                }
                while (true);

                switch (selectedOperation)
                {
                    case 1:
                        View(path, true);
                        break;
                    case 2:
                        Add(path, true);
                        break;
                    case 3:
                        Delete(path);
                        break;
                }
            } while (true);
        }
    }
}
