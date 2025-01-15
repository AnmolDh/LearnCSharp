namespace LearnCSharp
{
    internal class Threading
    {
        private static readonly object lockObject = new object();
        static void printNumUp(ref int num)
        {
            for (int i = 0; i < 10000; i++)
            {
                lock (lockObject)
                {
                    num++;
                    Console.Write(". ");
                    Thread.Sleep(10);
                }
            }
        }
        public static void runThread()
        {
            int num = 0;
            //printNumUp(ref num);
            Thread t1 = new Thread(() => printNumUp(ref num));
            Thread t2 = new Thread(() => printNumUp(ref num));
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(num);
        }
    }
}
