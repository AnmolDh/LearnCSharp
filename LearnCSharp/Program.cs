namespace LearnCSharp;

class Program
{

    //enum StatusCode
    //{
    //    success = 200,
    //    notfound = 404
    //}


    static void Main()
    {
        //Vehicle veh = new Car("Kia", "Sonet");
        //Person p1 = new Person("Anmol", 21, "AnmolDh", "hellokitty", veh);
        //Person p2 = new Person("jeefe", 11, "ajja", "jsjs", veh);
        //Person p3 = new Person("jeesfe", 11, "ajjsa", "jsssjs", veh);

        //var Persons = new List<Person>
        //{
        //    p1,
        //    p2,
        //    p3
        //};

        //string chkusr = "AnmolDh";
        //string chkpass = "hellokitty";

        //Console.WriteLine(Person.Auth(chkusr, chkpass, Persons));

        //p1.PrintPersonDetails();


        //var mp = new Dictionary<int, int>();
        //mp.Add(1, 10);
        //mp.Add(2, 20);
        //mp[3] = 30;
        //mp[4] = mp[1] + mp[3];

        //foreach (var m in mp)
        //{
        //    Console.WriteLine($"{m.Key}: {m.Value}");
        //}

        //StatusCode code = (StatusCode)404;
        //Console.WriteLine(code);


        //var list = new List<int>() { 2,3,13,41,133,112,344,14,131 };
        //IEnumerable<string> query = from i in list where i > 100 select $"number: {i}";

        //foreach (var i in query)
        //{
        //    Console.WriteLine(i);
        //}

        //int a = 839137;
        //int b = 21;

        //a = a ^ b;
        //b = a ^ b;
        //a = a ^ b;

        //Console.WriteLine($"{a} {b}");

        //Func<int, int, int> mul = (x, y) => x * y;
        //Action<String> greet = name => Console.WriteLine("hello");
        //Predicate<int> check = x => x % 2 == 0;
        //Console.WriteLine(mul(2, 3));

        //Threading.runThread();

        //Tasking.runTask().GetAwaiter().GetResult();

        //Tasking.llTask();

        //GuessNumber.Guess();

        ToDoList.RunTODO();
    }
}