namespace LMS
{
    internal class Book(string title, string author, string isbn, int nos)
    {
        public string Title
        {
            get { return title; }
        }

        public string Author
        {
            get { return author; }
        }

        public string ISBN
        {
            get { return isbn; }
        }

        public int NOS
        {
            get { return nos; }
            set { nos = value; }
        }
    }
}
