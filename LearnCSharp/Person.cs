namespace LearnCSharp
{
    internal class Person(string name, int age, string username, string password, Vehicle veh)
    {
        string name = name;
        int age = age;
        string username = username;
        string password = password;
        Vehicle veh = veh;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Vehicle Veh
        {
            get { return veh; }
            set { veh = value; }
        }

        public void PrintPersonDetails()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Vehicle: \n\tType: {Veh.type}\n\tBrand: {Veh.brand}\n\tModal: {Veh.Modal}");
        }

        public static bool Auth(string usr, string pass, List<Person> persons)
        {
            foreach (var p in persons)
            {
                if (p.Username == usr && p.Password == pass)
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
