namespace AuthorProblem
{
    using System;
    [Author("Ivalina")]
    public class StartUp
    {
        [Author("Marina")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
