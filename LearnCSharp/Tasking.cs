using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LearnCSharp
{
    internal class Tasking
    {
        static int num = 0;
        static void printNum()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(". ");
                num++;
                Task.Delay(10).Wait();
            }
        }

        static int returnNum()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(". ");
                num++;
            }
            return num;
        }

        public static async Task runTask()
        {
            Task task1 = Task.Run(printNum);

            Task<int> task2 = Task.Run(returnNum);
            int returnedNum = await task2;
            Console.WriteLine(returnedNum);

            task1.Wait();
            task2.Wait();

            Console.WriteLine(num);
        }


        public static void llTask()
        {
            var data = new string[] { "hekko", "hehe", "jsjaf", "jsajs", "sjajja"};

            Parallel.ForEach(data, item =>
            {
                Console.WriteLine($"Processing {item} on thread {Task.CurrentId}");
            });
        }
    }
}
