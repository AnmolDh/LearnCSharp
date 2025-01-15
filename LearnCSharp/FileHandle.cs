namespace LearnCSharp
{
    internal class FileHandle
    {
        public static void RunHandle()
        {
            string path = @"D:\Dev\test.txt";

            //File.WriteAllText(path, "Hello World");
            //string content = File.ReadAllText(path)
            //Console.WriteLine(content);


            if (!File.Exists(path))
            {
                using StreamWriter sw = File.CreateText(path);
                sw.WriteLine("hello");
                sw.WriteLine("world");
            }

            using StreamReader sr = File.OpenText(path);
            string s = sr.ReadToEnd();
            Console.WriteLine(s);
        }
    }
}
