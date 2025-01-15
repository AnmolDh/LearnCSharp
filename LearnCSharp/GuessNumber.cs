namespace LearnCSharp
{
    internal class GuessNumber
    {
        private static Random r = new();
        private static readonly int num = r.Next(0, 100);

        public static void Guess()
        {
            bool flag = true;
            do
            {
                int guessNum = Convert.ToInt32(Console.ReadLine());

                if (guessNum > num)
                {
                    Console.WriteLine("Your Guess is High!");
                    continue;
                }
                else if (guessNum < num)
                {
                    Console.WriteLine("Your Guess is Low!");
                    continue;
                }
                else
                {
                    Console.WriteLine("Well Done");
                    flag = false;
                }
            }
            while (flag);

            Console.WriteLine("You WON!!!");
        }
    }
}
