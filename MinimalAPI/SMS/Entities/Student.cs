
namespace SMS.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int RollNo { get; set; }
        public int Age { get; set; }
        public int Batch { get; set; }
    }
}
