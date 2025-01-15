namespace LearnCSharp
{
    abstract class Vehicle(string brand, string modal, string type)
    {
        public string type = type;
        public string brand = brand;
        public string modal = modal;
        public int wheels;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Modal
        {
            get { return modal; }
            set { modal = value; }
        }

        public int Wheels
        {
            get { return wheels; }
            set { wheels = value; }
        }

        abstract public void MakeNoise();
    }

    class Bike(string brand, string modal) : Vehicle(brand, modal, "Bike")
    {
        //public Bike(string brand, string modal)
        //{
        //    type = "Bike";
        //    this.brand = brand;
        //    this.modal = modal;
        //    wheels = 2;
        //}

        public override void MakeNoise()
        {
            Console.WriteLine("pee pee");
        }
    }

    class Car(string brand, string modal) : Vehicle(brand, modal, "Car")
    {
        //public Car(string brand, string modal) {
        //    type = "Car";
        //    this.brand = brand;
        //    this.modal = modal;
        //    wheels = 4;
        //}

        public override void MakeNoise()
        {
            Console.WriteLine("Poo Poo");
        }
    }
}
